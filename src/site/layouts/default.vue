<template>
  <div class="bg-grey">
    <NavBar class="fixed inset-x-0 top-0 z-20" />
    <div
      class="max-w-4xl mx-auto px-1 sm:px-5 md:px-6 py-28 md:py-40"
    >
      <Nuxt />
    </div>
    <PageFooter />
  </div>
</template>

<script>
import NavBar from '@/components/nav-bar.vue'
import PageFooter from '@/components/page-footer.vue'
export default {
  name: 'DefaultTemplate',
  components: { NavBar, PageFooter },
}
</script>
