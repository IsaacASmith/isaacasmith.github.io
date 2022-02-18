<template>
  <div>
    <NavBar class="fixed inset-x-0 top-0 z-20" />
    <div class="bg-grey">
      <div
        class="max-w-4xl mx-auto px-3 sm:px-5 md:px-6 pt-28 md:pt-40 py-5 md:py-10"
      >
        <Nuxt />
      </div>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/nav-bar.vue'
export default {
  name: 'DefaultTemplate',
  components: { NavBar },
}
</script>
