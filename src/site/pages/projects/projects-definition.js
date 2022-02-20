export default {
  projects: [
    {
      thumbnail: require('~/assets/img/projects/musinsights.png'),
      title: 'Musinsights',
      shortDesc:
        'A tool to pull listening analytics from the Spotify API and summarize your listening habits. Uses an azure function to compute insights.',
      prodUrl: 'https://musinsights.isaacsmith.us',
      codeUrl: 'https://github.com/IsaacASmith/Musinsights',
      technologies: ['Vue', 'Vuetify', 'C#', 'Azure Functions'],
    },
    {
      thumbnail: require('~/assets/img/projects/personal-site.png'),
      thumbnailAlt: 'Personal site webpage screenshot',
      title: 'This Website',
      shortDesc:
        'Re-built with Vue + Nuxt. The original site was built with plain html/css/js, but bringing in nuxt allows reuse of a variety of page components.',
      prodUrl: 'https://isaacsmith.us',
      codeUrl: 'https://github.com/IsaacASmith/isaacasmith.github.io',
      technologies: ['Vue', 'Nuxt', 'Tailwind CSS', 'GitHub Pages'],
    },
  ],
}
