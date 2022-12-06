<template>
  <div>
    <a :href="affiliate.link">Do it.</a>
  </div>
</template>

<script>
export default {
  name: 'AffiliateThing',
  data: () => ({
    affiliate: {
      link: 'https://savvycal.com/?via=isaac'
    }
  })
}
</script>
