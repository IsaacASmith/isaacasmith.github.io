<template>
  <div>
    <PostLayout
      :title="postDefinition.title"
      :publish-date="postDefinition.publishDate"
      :tags="postDefinition.tags"
      :thumbnail="postDefinition.thumbnail"
    >
      <p class="mb-1">
        Many web applications I build end up with the following security need:
      </p>
      <ul class="list-disc ml-6 mb-6">
        <li>99% of requests need to be authenticated</li>
        <li>1% of requests don't</li>
      </ul>
      <p class="mb-1">Seeing this need, many applications end up like this:</p>
      <ul class="list-disc ml-6 mb-6">
        <li>99% of controllers/routes have [Authorize] attributes on them</li>
        <li>1% of them don't</li>
      </ul>
      <h2 id="issues" class="mb-2 text-2xl font-bold">
        Issues with this setup
      </h2>
      <p class="mb-6">
        Sure, this gets the job done. You can ship your application and
        everything might be secured. But let's think through the implications of
        building the authentication this way.
      </p>
      <h3 class="mb-2 font-bold">
        Security Implications if an [Authorize] tag is missed
      </h3>
      <p class="mb-4">
        Let's imagine you're building an invoicing system. You've been working
        long hours to get the job done. As you're pushing towards the finish
        line, you get a little careless and forget to add an authorize tag on
        the GET endpoint that returns a list of all invoices in the system. You
        test everything and it appears to work great! Let's ship it.
      </p>
      <p class="mb-6">
        Well, unbeknownst to you, you just exposed all of the invoices to the
        world. Woops. This is something that can go unnoticed if no one is
        specifically reviewing for this type of flaw. Without some type of
        security review to make sure every endpoint is secured, this could
        easily slip by for a long time.
      </p>
      <h3 class="mb-2 font-bold">Extra clutter adding the [Authorize] tags</h3>
      <p class="mb-6">
        Let's say you have 20 controllers, with 4 endpoints in each controller.
        That's at least 20 lines of just [Authorize]. If you're setting it on
        every endpoint, that's 80. Yikes. This creates unnecessary noise as
        someone reads through the code.
      </p>
      <h2 id="implementation" class="mb-2 text-2xl font-bold">A better way</h2>
      <p class="mb-6">
        Let's flip our authentication thinking on its head. By adding
        [Authorize] attributes on every endpoint, we are essentially saying
        “everything is <strong>unauthenticated</strong>, unless I say otherwise.
        What if we flipped that around and said “everything is
        <strong>authenticated</strong>, unless I say otherwise”. We enforce the
        authentication requirement by default. This eliminates the need for us
        to explicitly say that our endpoint is authenticated every time we build
        one. This also eliminates the risk that we forget to mark an endpoint as
        authenticated.
      </p>
      <h3 class="mb-2 font-bold">Using a global authorize filter</h3>
      <p class="mb-4">
        To implement this change, we can leverage a global authorization filter.
        In our Program.cs application bootstrapping code, we can specify a
        filter that requires all requests to be authenticated.
      </p>
      <Gist
        gist="IsaacASmith/a3757e8cad6eb0598bdede8fc3e830de"
        :height="260"
      ></Gist>
      <p class="mb-4">
        This example is in .NET 6, but a similar solution can be created in
        older versions of .NET Core using the Startup.cs file.
      </p>
      <p class="mb-4">
        Adding this code will require every request to be authenticated. Pretty
        simple. This does not enforce any specific role requirement. You can add
        additional [Authorize] tags with specific role requirements throughout
        the application to narrow down the users allowed to access specific
        areas. You can also add a base level role requirement for all requests
        by using the .RequireRole() method on the policy builder.
      </p>
      <Gist
        gist="IsaacASmith/3a88f26c08dc8d312d2e212f1e02a60f"
        :height="280"
      ></Gist>
      <p class="mb-6">
        I have found this useful when building applications that leverage a
        shared identity store such as azure AD. If we want to restrict access
        within an organization to only users who are in a specific security
        group, we can use .RequireRole() to require that base access level.
      </p>
      <p class="mb-4">
        Note: These examples exclude the authentication setup itself, e.g.
        setting up azure AD or ASP.NET identity integrations.
      </p>
      <h3 class="mb-2 font-bold">
        But what if we need to make some requests anonymous?
      </h3>
      <p class="mb-6">
        No problem. Simply add the [AllowAnonymous] attribute to any controllers
        or endpoints that need to be open. Places like login pages or user
        registration typically end up getting these.
      </p>
      <p class="flex flex-row justify-center mt-4 mb-8 text-xl font-bold">
        . . .
      </p>
      <h2 class="mb-2 text-2xl">
        <strong>Wrap Up</strong>
      </h2>
      <p class="mb-6">
        When it comes to authentication and authorization, there are many ways
        to implement it. By using a global authorization filter, we can save
        ourselves the headaches of adding [Authorize] attributes all over our
        controllers, as well as ensuring every endpoint is protected by default.
      </p>
    </PostLayout>
  </div>
</template>

<script>
import PostLayout from '@/components/post-layout.vue'
import blogDefinition from '~/plugins/blog-definition.js'
import Gist from '~/components/gist.vue'

export default {
  components: { PostLayout, Gist },
  data: () => ({
    blogDefinition,
  }),
  head() {
    return {
      title: 'Securing ASP.NET Apps With Global Authorization Filters',
      meta: [
        {
          hid: 'secure-aspnet-filters-description',
          name: 'description',
          content:
            'Requiring authentication by default will protect our application from code bloat as well as missed [Authorize] tags, which could expose our data to the world.',
        },
      ],
    }
  },
  computed: {
    postDefinition() {
      return this.blogDefinition.posts.find(
        (post) => post.url === '/blog/2022/aspnet-global-authorization-filters'
      )
    },
  },
}
</script>
