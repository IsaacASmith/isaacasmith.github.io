export default {
  target: 'static',

  head: {
    title: 'Home | Isaac Smith',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { name: 'format-detection', content: 'telephone=no' },
      {
        name: 'description',
        content:
          "Hi! I'm Isaac. I'm a software engineering consultant in Sioux Falls, South Dakota.",
      },
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
        content: 'https://isaacsmith.us',
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
      {
        property: 'twitter:image:alt',
        content: 'A person on their smartphone shopping for gifts to share',
      },
    ],
    script: [
      {
        hid: 'fathom',
        src: 'https://cdn.usefathom.com/script.js',
        defer: true,
        'data-site': 'XGBKSFUH',
        'data-spa': true
      },
    ],
    link: [{ rel: 'icon', type: 'image/x-icon', href: '/favicon.png' }],
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
