<template>
  <div class="bg-grey">
    <NavBar class="fixed inset-x-0 top-0 z-20" />
    <div class="max-w-4xl mx-auto px-1 sm:px-5 md:px-6 pt-28 pb-20 md:pt-40 md:pb-32">
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
  mounted: () => {
    // const pageViewURL = 'http://localhost:7071/api/view'
    const pageViewURL = 'https://fa-metr-personal-site.azurewebsites.net/api/view'

    const getClientId = () => ''
      .concat('3286f0be-14f8').concat('|')
      .concat(window.screen.height).concat('|')
      .concat(window.screen.width).concat('|')
      .concat(window.navigator.language).concat('|')
      .concat(window.navigator.hardwareConcurrency).concat('|')
      .concat(window.navigator.userAgent).concat('|')
      .concat(window.navigator.oscpu).concat('|')

    const hashCode = s => s.split('').reduce((a, b) => (((a << 5) - a) + b.charCodeAt(0)) | 0, 0)

    const urlParams = new URLSearchParams(window.location.search);

    fetch(pageViewURL, {
      method: "POST",
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        path: window.location.pathname,
        referrer: document.referrer,
        screenWidth: window.screen.width,
        client: hashCode(getClientId()),
        utm: {
          medium: urlParams.get('med'),
          source: urlParams.get('src'),
          campaign: urlParams.get('cam'),
          content: urlParams.get('con')
        }
      })
    })
  }
}
</script>
