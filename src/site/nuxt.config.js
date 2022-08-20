export default {
  target: 'static',
  sitemap: {
    hostname: 'https://www.isaacsmith.us',
  },
  generate: {
    dir: './dist'
  },
  head: {
    title: 'Isaac Smith | Software Engineering',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { name: 'format-detection', content: 'telephone=no' },
      {
        property: 'og:title',
        content: 'Isaac Smith',
      },
      {
        property: 'og:site_name',
        content: 'Isaac Smith',
      },
      {
        property: 'og:type',
        content: 'website',
      },
      {
        property: 'og:url',
        content: 'https://www.isaacsmith.us',
      },
      {
        property: 'twitter:title',
        content: 'Isaac Smith',
      },
      {
        property: 'twitter:description',
        content: 'A software engineering consultant in the midwest.',
      },
      {
        property: 'twitter:site',
        content: '@isaac_smith3',
      },
      {
        property: 'twitter:creator',
        content: '@isaac_smith3',
      },
    ],
    link: [{ rel: 'icon', type: 'image/x-icon', href: '/favicon.png' }],
  },

  router: {
    middleware: 'page-viewed'
  },

  css: [],

  plugins: ['@/plugins/dateUtils.js'],

  components: true,

  buildModules: ['@nuxtjs/eslint-module', '@nuxtjs/tailwindcss'],

  modules: ['@nuxtjs/pwa', '@nuxtjs/sitemap'],

  pwa: {
    manifest: {
      lang: 'en',
    },
  },

  build: {},
}
