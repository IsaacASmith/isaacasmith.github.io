<template>
  <div>
    <PostLayout
      :title="postDefinition.title"
      :publish-date="postDefinition.publishDate"
      :tags="postDefinition.tags"
      :thumbnail="postDefinition.thumbnail"
    >
      <p class="mb-6">
        I recently came across a scenario where I needed to authorize http
        requests between an azure function and an azure web app. Azure Managed
        Identity provides a secure and structured method for granting this
        access with very little custom auth code required.
      </p>
      <p class="mb-6">
        Find the full source code
        <a
          href="https://github.com/IsaacASmith/blog/tree/master/service-auth-using-msi"
          target="_blank"
          rel="nofollow"
          class="underline"
        >on GitHub</a>.
      </p>
      <p class="mb-2">This tutorial assumes you have the following resources provisioned in Azure:</p>
      <ul class="list-decimal ml-5 mt-1 mb-6">
        <li>An App Service</li>
        <li>An Azure Function App</li>
      </ul>
      <h2 class="mb-4 text-xl">
        <strong>System Architecture</strong>
      </h2>
      <img
        src="~/assets/img/blog/2022/service-id-auth/system-architecture.png"
        class="pb-6"
        alt="System architecture showing azure function retrieving access token, passing to web api, and being validated."
      />
      <p class="mb-2">The flow for this solution follows these steps:</p>
      <ul class="list-decimal ml-5 mt-1 mb-8">
        <li>Azure function obtains a JWT bearer token from our Azure AD app registration</li>
        <li>Azure function provides the bearer token when making http requests to the web API</li>
        <li>Web API validates the authenticity of the access token and reads JWT claims</li>
      </ul>
      <h2 class="mb-4 text-2xl">
        <strong>Tutorial</strong>
      </h2>
      <h3 class="mb-4 text-xl">
        <strong>Creating the Azure AD App Registration</strong>
      </h3>
      <p class="mb-6">
        Before we can authenticate our applications, we first need an AD app registration
        to delegate our permissions and role assignments.
      </p>
      <img
        src="~/assets/img/blog/2022/service-id-auth/create-registration.png"
        class="pb-6"
        alt="Screenshot of the app registration blade in azure AD, with the new registration button highlighted."
      />
      <p class="mb-6">
        Feel free to name this app registration anything appropriate. For this demo I
        named it demo-web-api. Next we need to define the roles to be delegated. In this
        scenario we will create 2 roles for demonstration purposes: Data Reader and Data
        Writer. We can manage these roles in the "App roles" blade within our app
        registration. For service-to-service authorization, we can limit the allowed member
        types to just applications. If you would like to use this app registration to manage
        roles for user of the app, you can select one of the Users/Groups options.
      </p>
      <img
        src="~/assets/img/blog/2022/service-id-auth/create-role.png"
        class="pb-6"
        alt="Screenshot of the app registration blade in azure AD, showing the new app role blade."
      />
      <p class="mb-6">Once created, your roles should look something like the following.</p>
      <img
        src="~/assets/img/blog/2022/service-id-auth/created-roles.png"
        class="pb-6"
        alt="Screenshot of the app registration blade in azure AD, showing the created app roles."
      />
      <p class="mb-6">
        Take note of the "ID" values for each role you create, we'll need them shortly.
        That's all the setup we need for our app registration. We'll come back later to
        grab a few IDs, but for now we can move on to grant roles to our Azure Function.
      </p>
      <h3 class="mb-4 text-xl">
        <strong>Granting Roles</strong>
      </h3>
      <p class="mb-6">
        The first step to granting our Azure function access to the web API is to turn
        on managed service identity (MSI). This gives us an object ID we can use to
        refer to the function from Azure AD. To turn this on, simply go to the Identity
        tab under the Azure Function.
      </p>
      <img
        src="~/assets/img/blog/2022/service-id-auth/enable-msi.png"
        class="pb-6"
        alt="Screenshot of the azure function app, showing how to enable the identity blade by switching the status to on."
      />
      <p
        class="mb-6"
      >Once MSI auth is on, you can take note of the Object ID displayed. We will need this shortly.</p>
      <p class="mb-6">
        Next we need to grant the role to our Azure Function so it will be returned in the access
        token provided by the app registration. It would be great if the Azure portal provided
        a UI for adding Application roles, but unfortunately as of writing this post, the
        portal only supports granting User roles. For this task, we'll need to use PowerShell.
      </p>
      <p class="mb-2">You will need the following IDs to run the script:</p>
      <ul class="list-disc ml-5 mt-1 mb-8">
        <li>Tenant Id: Can be found on the overview page of Azure AD.</li>
        <li>Web API Enterprise App Object ID: Can be found at Active Directory -> Enterprise Applications -> Your App Name -> Overview -> Object ID</li>
        <li>Function App Object ID: Created in the previous step, under Function App -> Identity -> Object ID</li>
        <li>Data Reader Role ID: The ID value from creating the Data Reader role earlier</li>
        <li>Data Writer Role ID: The ID value from creating the Data Writer role earlier</li>
      </ul>
      <p class="mb-6">
        Here is the script to assign the roles once you have gathered the IDs you need.
        You will need the Azure PowerShell Module to run this. You may also need to
        install the AzureAD powershell module separately.
      </p>
      <Gist gist="IsaacASmith/9a288dc8d2027649373dd9a0799a469b" :height="600" />
      <p class="mb-6">
        Once the script completes, we can check that the roles were assigned properly
        by navigating to our Enterprise App Registration and viewing the role assignments.
      </p>
      <img
        src="~/assets/img/blog/2022/service-id-auth/enterprise-app-assignments.png"
        class="pb-6"
        alt="Screenshot of the demo api enterprise application with the data reader/writer roles assigned to the azure function."
      />
      <p class="mb-6">Now we're ready to utilize these roles for access control.</p>
      <h3 class="mb-4 text-xl">
        <strong>Creating the Web API</strong>
      </h3>
      <p class="mb-6">
        We will next create a simple web API project and configure it to use
        the app registration we created earlier to handle authentication.
      </p>
      <p class="mb-5">To create the web API project, we can run the following command</p>
      <CodeBlock code="dotnet new webapi" class="mb-6" />
      <p
        class="mb-5"
      >We will also need the JwtBearer nuget package to help us configure the authentication.</p>
      <CodeBlock
        code="dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer"
        class="mb-6"
      />
      <p class="mb-6">
        Next, we need to modify the Startup.cs file to include our authentication/authorization setup.
        First modify the ConfigureServices method to set up our JWT authentication:
      </p>
      <Gist gist="IsaacASmith/d45fbf942ad16420effd51e379f8691d" :height="650" />
      <p class="mb-6">
        We also need to add our Authentication/Authorization to the Configure method to
        have the web app use what we have set up so far:
      </p>
      <Gist gist="IsaacASmith/2d017fb268db6e8c30db5409ecd052dc" :height="400" />
      <p class="mb-6">
        <strong>IMPORTANT NOTE:</strong> The order of these app.Use() calls is key.
      </p>
      <p class="mb-6">
        Once those pieces are in place in Startup.cs, we are ready to authenticate and authorize
        the requests we receive. Here is a demo controller we can use to test the
        enforcement of our read and write roles we created earlier.
      </p>
      <Gist gist="IsaacASmith/8f49475549aaa17eaf638e3959392ac5" :height="570" />
      <h3 class="mb-4 text-xl">
        <strong>Creating the Azure Function</strong>
      </h3>
      <p class="mb-5">
        Now that our web API is set up, we can create a simple function app
        to test that our roles and access have been assigned properly. We can start
        by initializing a new function app.
      </p>
      <CodeBlock code="func init az-func --dotnet" class="mb-6" />
      <p
        class="mb-5"
      >To obtain and manage our API access tokens, we can install the app authentication nuget package.</p>
      <CodeBlock code="dotnet add package Microsoft.Azure.Services.AppAuthentication" class="mb-6" />
      <p class="mb-6">
        Once our function app project is created, we can create a simple HTTP triggered
        function to test out our access to the web API.
      </p>
      <Gist gist="IsaacASmith/a848411ff94cb9334914e713f090e484" :height="820" />
      <p class="mb-2">Here is a breakdown of what happens in this function:</p>
      <ul class="list-decimal ml-5 mt-1 mb-8">
        <li>We create an Azure service token provider and use it to obtain an access token (JWT) for our web API app registration, based on the client ID.</li>
        <li>We create a request to our web API, with the bearer token added to the request headers.</li>
        <li>We send the request and get a message back from the web API, meaning we have successfully authenticated. If our authentication had failed, we would receive a 401 response code.</li>
      </ul>
      <p class="mb-6">
        Once our function app has been deployed to Azure, we can test it out. Here is
        the message returned from our hosted Azure Function, including the result of our web API call:
      </p>
      <img
        src="~/assets/img/blog/2022/service-id-auth/success-result.png"
        class="pb-6"
        alt="Screenshot of a success message from the function authenticating to the web api."
      />
      <h3 class="mb-4 text-xl">
        <strong>Inspecting the JWT to Help Debug Issues</strong>
      </h3>
      <p class="mb-6">
        The JWT returned by our Azure AD app registration can be inspected using various JWT tools.
        You will likely need to remote debug your function app to grab this value, or you can create
        a dummy function to return the JWT value (this would expose the JWT to the public, so it should
        only be done for initial testing/setup). Inspecting the JWT can be a good sanity check to make
        sure that our roles and client ID are correctly configured. Below is an example of what you may
        see if you plug in your JWT to
        <a
          href="https://jwt.io"
          target="_blank"
          rel="nofollow"
        >https://jwt.io</a>
      </p>
      <img
        src="~/assets/img/blog/2022/service-id-auth/jwt-inspected.png"
        class="pb-6"
        alt="Screenshot of the decoded JWT on jwt.io."
      />
      <p
        class="mb-6"
      >The "aud" field here should match the value of your app registration client ID.</p>
      <p class="mb-6">The "iss" field should end with the tenant ID of your AD tenant.</p>
      <p
        class="mb-10"
      >The "roles" list should include the roles we assigned to our Azure Function using PowerShell.</p>
      <p class="flex flex-row justify-center mt-4 mb-8 text-xl font-bold">. . .</p>
      <p class="mb-2 text-xl">
        <strong>Wrap Up</strong>
      </p>
      <p class="mb-6">
        Now you know how to secure service to service requests using Azure Managed
        Identity. This tutorial used an azure function as the client application,
        but any Azure service that can use managed identity can leverage this method
        (e.g. another App Service).
      </p>
    </PostLayout>
  </div>
</template>

<script>
import PostLayout from '~/components/post-layout.vue'
import Gist from "~/components/gist.vue";
import CodeBlock from '~/components/code-block.vue';
import blogDefinition from '~/plugins/blog-definition.js'

export default {
  components: { PostLayout, Gist, CodeBlock },
  data: () => ({
    blogDefinition,
  }),
  head() {
    return {
      title: 'Azure Managed Identity: Authorize Service-to-Service Requests',
      meta: [
        {
          hid: 'authorize-service-requests',
          name: 'description',
          content:
            'Delivering a website through a CDN can give you headaches when it comes to CSPs. Luckily there is a way to deliver CSPs without headers.',
        },
      ],
    }
  },
  computed: {
    postDefinition() {
      return this.blogDefinition.posts.find(
        (post) => post.url === '/blog/2022/azure-managed-identity-authorize-service-requests'
      )
    },
  },
}
</script>
