<template>
  <div class="bg-grey">
    <NavBar class="fixed inset-x-0 top-0 z-20" />
    <div
      class="max-w-4xl mx-auto px-1 sm:px-5 md:px-6 pt-28 pb-20 md:pt-40 md:pb-32"
    >
      <Nuxt />
    </div>
    <PageFooter />
  </div>
</template>

<script>
import NavBar from '@/components/nav-bar.vue'
import PageFooter from '@/components/page-footer.vue'
import pageViewedFunc from '@/middleware/page-viewed'

export default {
  name: 'DefaultTemplate',
  components: { NavBar, PageFooter },
  mounted() {
    const context = {
      route: this.$route,
      from: {
        path: '',
      },
    }
    pageViewedFunc(context)
  },
}
</script>
