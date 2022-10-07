<template>
  <div>
    <PostLayout :title="nuxtSEOBasicsPostDefinition.title" :publish-date="nuxtSEOBasicsPostDefinition.publishDate"
      :tags="nuxtSEOBasicsPostDefinition.tags" :thumbnail="nuxtSEOBasicsPostDefinition.thumbnail">
      <p class="mb-2">
        Nuxt is a popular framework for building Vue.js applications with server side/static rendering capabilities. It
        does a whole lot more, but in this article we'll focus on implementing SEO best practices with the framework.
        Specifically:
      </p>
      <ul class="list-decimal underline ml-6 mb-10">
        <li>
          <a href="#spa-seo-issues">The issue with SPAs and SEO</a>
        </li>
        <li>
          <a href="#html-titles">HTML titles</a>
        </li>
        <li>
          <a href="#meta-descriptions">Meta descriptions</a>
        </li>
        <li>
          <a href="#dynamic-sitemaps">Dynamic sitemaps</a>
        </li>
        <li>
          <a href="#social-meta-tags">Social meta tags</a>
        </li>
      </ul>
      <h2 class="mb-2 text-xl">
        <strong>The issue with SPAs and SEO</strong>
      </h2>
      <p class="mb-6">
        Search engine crawlers need HTML content to determine what your page is all about. If you're running a
        traditional JavaScript SPA, you're most likely relying on a combination of JavaScript executing and API calls
        being made to populate the contents of the page. Although Google is getting better at indexing pages that work
        this way, the tried and true method of delivering fully hydrated HTML to the browser is still the best way to
        reliably build SEO into your pages. Using Nuxt allows you to deliver fully hydrated HTML to the browser when the
        page loads. This ensures that all search engines are able to index the content on your page. Using “Universal
        mode” with nuxt will give you this functionality out of the box.
      </p>
      <h2 class="mb-2 text-xl">
        <strong>HTML Titles</strong>
      </h2>
      <p class="mb-6">
        Step zero of any on-page SEO is giving a page a title. This is one of the primary factors used by search engines
        to determine what a page is all about. Nuxt gives you two options to configure page titles.
      </p>

      <h3 class="mb-2 text-lg font-semibold">
        Global page titles
      </h3>
      <p class="mb-4">
        Using the nuxt.config.js file in the root of the nuxt app, you can specify a template for the title of every
        page in your application. By inserting a %s in the title string will fill in the name of the individual page,
        along with the rest of the string on every page. For example, the following template would create the title
        “Nuxt SEO - seoforbeginners.com” on a page with the title “Nuxt SEO”
      </p>
      <Gist gist="IsaacASmith/78debdeeead6f33f6792c9705d5e8b9d" :height="225" />
      <p class="mb-6">
        You are not required to use a template if you want to have completely unique page titles, but templates are
        great for consistency across your website.
      </p>

      <h3 class="mb-2 text-lg font-semibold">
        Page specific titles
      </h3>
      <p class="mb-4">
        On individual pages, you can specify the title using the head section of your script. You can either statically
        set it using an object, or you can define a head() function and set it dynamically based on different data on
        your page.
      </p>
      <Gist gist="IsaacASmith/3c95b4c51e3cb2400705f5c3c8e15fbb" class="mb-6" :height="260" />
      <h2 class="mb-2 text-xl">
        <strong>Meta descriptions</strong>
      </h2>
      <p class="mb-4">
        Arguably the second most important on-page SEO feature coming in after the page title is the meta description of
        your page. This is a longer description of your page that search engines can use to display a snippet of
        information to users on the search engine results page (SERP) about your page. Nuxt lets you set this
        description on each page using the head script section on the page, just like the title.
      </p>
      <Gist gist="IsaacASmith/f211bdbf6e3ed9a6c9b620d006a82716" class="mb-1" :height="420" />

      <p class="mb-4">
        You can also dynamically generate this description based on different conditions.
      </p>
      <Gist gist="IsaacASmith/f0c47b4cb14d76004c4f095b5fa5c2ca" class="mb-1" :height="460" />

      <p class="mb-6">
        Just like any other site, it's recommended to keep your description text between 50 and 160 characters. Going
        longer will often cause your description to be cut off in the SERP.
      </p>

      <h2 class="mb-2 text-xl">
        <strong>Dynamic sitemaps</strong>
      </h2>
      <p class="mb-4">
        Tired of updating your sitemap every time you add a new page? Look no further. Nuxt can generate a sitemap for
        you based on the pages linked within your application. It's a quick process, just run 
        <CodeBlock class="my-3" code="npm install @nuxtjs/sitemap"></CodeBlock>
        Then add the following to your nuxt.config.js file.
      </p>
      <Gist gist="IsaacASmith/9450913af14d5f7aacc02fd0396b7dac" class="mb-1" :height="240" />

      <p class="mb-6">
        Then you can head over to the /sitemap.xml route on your website and view the full sitemap. This is a quick way
        to generate a sitemap and get it ready for submitting to google. More details on the Nuxt sitemap module can
        be found <a class="underline" href="https://sitemap.nuxtjs.org/" target="_blank">in their docs</a>.
      </p>

      <h2 class="mb-2 text-xl">
        <strong>Social meta tags</strong>
      </h2>
      <p class="mb-4">
        While social meta tags may not necessarily be required for SEO, they are a great way to improve click through
        when sharing links to your site to social media. Nuxt makes it easy to add these meta tags along with the other
        features we've discussed so far. You can add them either at the nuxt.config.js level to have them globally
        applied, or you can place the tags on individual pages to customize the tag on a per-page basis. Here's an
        example of adding social meta tags to the nuxt.config.js file.
      </p>
      <Gist gist="IsaacASmith/e9f4dfcd955523bd9d5839bc180f7d80" class="mb-6" :height="420" />

      <p class="flex flex-row justify-center mt-4 mb-8 text-xl font-bold">. . .</p>
      <h2 class="mb-2 text-xl">
        <strong>Wrap Up</strong>
      </h2>
      <p class="mb-6">
        Nuxt is a great tool for building high-end Vue applications. The server side/static rendering capabilities give
        us the ability to implement SEO best practices that are often much more difficult in a traditional SPA. We can
        deliver fully hydrated HTML to the browser, with all of our meta/title content ready to go for search engines to
        pick up.

      </p>
    </PostLayout>
  </div>
</template>

<script>
import PostLayout from '@/components/post-layout.vue'
import blogDefinition from '~/plugins/blog-definition.js'
import Gist from '~/components/gist.vue'
import CodeBlock from '~/components/code-block.vue'

export default {
  components: { PostLayout, Gist, CodeBlock },
  data: () => ({
    blogDefinition,
  }),
  head() {
    return {
      title: 'Nuxt SEO: The Basics of On-Page SEO',
      meta: [
        {
          hid: 'nuxt-seo-page-description',
          name: 'description',
          content:
            `Nuxt is a great tool to do on-page SEO work. It lets you set titles, meta tags, and sends fully hydrated HTML to the browser.`,
        },
      ],
    }
  },
  computed: {
    nuxtSEOBasicsPostDefinition() {
      return this.blogDefinition.posts.find(
        (post) => post.url === '/blog/2022/nuxt-seo-basics'
      )
    },
  },
}
</script>
