<template>
  <a :href="affiliate.link" target="_blank" rel="noopener" @click="linkClicked">
    <div
      class="my-4 p-4 rounded bg-gray-100 columns-2 gap-8 items-center border-solid border-2 border-sky-500"
    >
      <div>
        <img
          :src="affiliate.img"
          width="124"
          height="32"
          style="height: 32px; width: 124px"
          class="mb-2"
        />
      </div>
      <div class="w-full leading-6">
        {{ affiliateTagline }}<span class="text-gray-500">*</span>
      </div>
    </div>
  </a>
</template>

<script>
import sanityMetrics from '~/plugins/sanity-metrics/sanity-metrics'

export default {
  name: 'AffiliateThing',
  data: () => ({
    affiliate: {},
    affiliateTagline: {},
    affiliates: [
      {
        id: 1,
        name: 'SavvyCal',
        link: 'https://savvycal.com/?via=isaac',
        img: require('~/assets/img/affiliates/savvycal.svg'),
        taglines: [
          'Tired of scheduling headaches? SavvyCal is the thoughtful way to find a time to meet.',
          "Take control of your schedule. SavvyCal lets you meet on your terms, when you're ready.",
        ],
      },
    ],
  }),
  mounted() {
    this.affiliate = this.getRandomItem(this.affiliates)
    this.affiliateTagline = this.getRandomItem(this.affiliate.taglines)
  },
  methods: {
    getRandomItem(list) {
      return list[Math.floor(Math.random() * list.length)]
    },
    linkClicked() {
      const context = {
        route: this.$route,
        from: {
          path: '',
        },
      }
      sanityMetrics.logEvent(context, 'affiliate-clicked', {
        affiliateId: this.affiliate.id,
        affiliateName: this.affiliate.name,
        tagline: this.affiliateTagline
      })
    },
  },
}
</script>
