<template>
  <div>
    <section class="flex flex-col items-center">
      <img
        src="~/assets/img/blog.svg"
        width="90"
        alt="Book icon"
        class="block"
      />
      <h1 class="text-2xl font-semibold mt-4">The Blog</h1>
      <div class="mt-4 mx-3">
        I write about all things software development, the relationship between
        technology and business, and continual improvement. These posts mostly
        come from my experiences as a software engineering consultant working
        with a variety of businesses across many sectors of the economy.
      </div>
      <div class="mt-16 text-3xl">Coming Soon!</div>
    </section>
    <!-- <section class="sm:mx-3">
      <div class="grid grid-cols-12 gap-4 mt-8 mx-3 md:mx-0">
        <input
          placeholder="Search posts..."
          class="col-span-12 sm:col-span-4 py-2 px-3 outline-none"
        />
        <input
          placeholder="Filter categories..."
          class="hidden sm:inline col-span-12 sm:col-span-4 py-2 px-3 outline-none"
        />
        <input
          placeholder="Sort by..."
          class="hidden sm:inline col-span-12 sm:col-span-4 py-2 px-3 outline-none"
        />
      </div>
      <div class="grid grid-cols-12 gap-4 mt-8">
        <nuxt-link
          v-for="post in blogDefinition.posts"
          :key="post.url"
          :to="post.url"
          class="col-span-12 sm:col-span-6 bg-white rounded p-4 sm:p-6 mx-2 sm:mx-0"
        >
          <div class="text-xl font-semibold">{{ post.title }}</div>
          <div class="text-sm text-gray-600 mt-1">
            {{ post.publishDate | formatMonthYear }}
          </div>
          <div class="mt-1">
            {{ post.shortDesc }}
          </div>
          <div class="flex flex-row mt-3">
            <div
              v-for="tag in post.tags"
              :key="tag"
              class="px-2 py-1 bg-primary text-white mr-2 rounded text-xs"
            >
              {{ tag }}
            </div>
          </div>
        </nuxt-link>
      </div>
    </section> -->
  </div>
</template>

<script>
import blogDefinition from '~/plugins/blog-definition'

export default {
  name: 'BlogIndex',
  data: () => ({
    blogDefinition,
    pageNumber: 1,
    pageSize: 10,
  }),
  head() {
    return {
      title: 'Blog | Isaac Smith',
      meta: [
        {
          hid: 'blog-description',
          name: 'description',
          content:
            'I write about all things software development, the relationship between technology and business, and continual improvement.',
        },
      ],
    }
  },
  computed: {
    pageCount() {
      return this.blogDefinition.length / this.pageSize
    },
    displayedBlogs() {
      return this.blogDefinition
    },
  },
}
</script>
