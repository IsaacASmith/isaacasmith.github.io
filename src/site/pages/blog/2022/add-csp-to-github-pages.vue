<template>
  <div>
    <PostLayout
      :title="cspPostDefinition.title"
      :publish-date="cspPostDefinition.date"
      :tags="cspPostDefinition.tags"
    >
      <div>Inside!</div>
    </PostLayout>
  </div>
</template>

<script>
import PostLayout from '@/components/post-layout.vue'
import blogDefinition from '~/plugins/blog-definition.js'

export default {
  components: { PostLayout },
  data: () => ({
    blogDefinition,
  }),
  computed: {
    cspPostDefinition() {
      return this.blogDefinition.posts.find(
        (post) => post.url === 'blog/2022/add-csp-to-github-pages'
      )
    },
  },
}
</script>
