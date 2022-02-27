<template>
  <div>
    <PostLayout
      :title="cspPostDefinition.title"
      :publish-date="cspPostDefinition.date"
      :tags="cspPostDefinition.tags"
      :thumbnail="cspPostDefinition.thumbnail"
    >
      <p class="mb-6">
        Content security policies (CSPs) have been around for years and are a
        great way to provide blanket protection from a variety of web page
        vulnerabilities. CSPs are typically delivered to a browser using a
        response header from the web server called
        <i>Content-Security-Policy</i>. This works great and provides the
        broadest range of support for CSP features.
      </p>
      <p class="mb-8">
        But what if we have no control over the HTTP responses from the web
        server? When a site is hosted on GitHub pages (or any other CDN), there
        is no access to the web server, so we can’t return our own response
        headers. The following solution will work for any hosting environment
        where we can’t modify response headers.
      </p>
      <h2 class="mb-2 text-xl">
        <strong>How to Implement</strong>
      </h2>
      <p class="mb-6">
        Enter the CSP
        <strong>&lt;meta&gt;</strong> tag.
      </p>
      <p class="mb-6">
        When modifying response headers is not an option, we have an alternative
        method for adding a CSP: using a meta tag.
      </p>
      <Gist gist="IsaacASmith/32646ca2d62d16fd86d6bb8705b00a49" class="mb-6" :height="90" />
      <p class="mb-6">
        This meta tag will go in the &lt;head&gt; element of the page, before
        our content, links, and scripts. The ‘http-equiv’ value is a constant,
        and the ‘content’ field is the policy we would like to enforce. The
        format for the CSP definition is the same as what would be sent in the
        response header. To read more about how to build a content security
        policy, go
        <a
          class="underline"
          href="https://developer.mozilla.org/en-US/docs/Web/HTTP/CSP"
          rel="nofollow"
          target="_blank"
        >here</a>.
      </p>
      <p class="mb-6">
        We can also specify multiple CSP meta tags to accomplish specific needs,
        just like using the header-based approach.
      </p>
      <p class="mb-6">
        Here is a more complete example of what the head of our HTML document
        might look like.
      </p>
      <Gist gist="IsaacASmith/5a12969f6c25ae30d41835485659ea4d" class="mb-6" :height="300" />
      <h2 class="mb-2 text-xl">
        <strong>Gotchas</strong>
      </h2>
      <p class="mb-6">
        There are a few issues we may run in to when implementing a CSP using
        the meta tag.
      </p>
      <h3 class="mb-2 text-lg">
        <strong>Including content before the CSP meta tag</strong>
      </h3>
      <p class="mb-6">
        If any content links appear before the CSP meta tag, the CSP will not
        apply to them. For example, the following sample will load the CSS file
        'stealyourdata.css', even though our CSP should be blocking it.
      </p>
      <Gist gist="IsaacASmith/babc73971b7cc395838fc6b03daad66d" class="mb-6" :height="290" />
      <h3 class="mb-2 text-lg">
        <strong>Using CSP directives not supported in meta tags</strong>
      </h3>
      <p class="mb-6">
        There is a short list of CSP directives that will not work when
        delivered using a meta tag. We will want to make sure our site does not
        rely on these directives to operate. The unsupported directives are:
      </p>
      <ul class="list-disc ml-5 mt-1">
        <li>report-uri</li>
        <li>frame-ancestors</li>
        <li>sandbox</li>
      </ul>
      <p class="flex flex-row justify-center mt-4 mb-8 text-xl font-bold">. . .</p>
      <h2 class="mb-2 text-xl">
        <strong>Wrap Up</strong>
      </h2>
      <p class="mb-6">
        While delivering content security policies using a response header is
        the preferred method, we can still meet our needs in environments where
        we cannot control response headers. If you are interested in learning more
        about content security policies, see the
        <a
          class="underline"
          href="https://developer.mozilla.org/en-US/docs/Web/HTTP/CSP"
          rel="nofollow"
          target="_blank"
        >official docs</a>.
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
      title: 'Add a Content Security Policy to a GitHub Pages Site',
      meta: [
        {
          hid: 'csp-github-pages-description',
          name: 'description',
          content:
            'Delivering a website through a CDN can give you headaches when it comes to CSPs. Luckily there is a way to deliver CSPs without headers.',
        },
      ],
    }
  },
  computed: {
    cspPostDefinition() {
      return this.blogDefinition.posts.find(
        (post) => post.url === '/blog/2022/add-csp-to-github-pages'
      )
    },
  },
}
</script>
