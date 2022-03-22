export default {
  posts: [
    {
      thumbnail: require('~/assets/img/blog/2022/aspnet-global-auth/icon.svg'),
      title: 'Securing ASP.NET Apps With Global Authorization Filters',
      shortDesc:
        'Let\'s flip our authentication thinking on its head and enforce the authentication requirement by default. This eliminates the ...',
      url: '/blog/2022/aspnet-global-authorization-filters',
      tags: ['Technical', 'ASP.NET', 'Security'],
      publishDate: new Date(2022, 2, 20),
    },
    {
      thumbnail: require('~/assets/img/blog/2022/ef-vs-dapper/icon.svg'),
      title: 'Choosing Between Entity Framework and Dapper',
      shortDesc:
        'Dapper and EF are two of the most popular ORMs in the .NET ecosystem. There are various reasons to choose one over the other  ...',
      url: '/blog/2022/entity-framework-vs-dapper',
      tags: ['Technical', '.NET', 'SQL'],
      publishDate: new Date(2022, 1, 27),
    },
    {
      thumbnail: require('~/assets/img/blog/2022/github-csp/icon.svg'),
      title: 'Adding a Content Security Policy to Your GitHub Pages Site',
      shortDesc:
        'Content security policies (CSPs) have been around for years and are a great way to provide blanket protection from various web...',
      url: '/blog/2022/add-csp-to-github-pages',
      tags: ['Technical', 'Web', 'Security'],
      publishDate: new Date(2022, 1, 18),
    },
    {
      thumbnail: require('~/assets/img/blog/2022/service-id-auth/icon.svg'),
      title: 'Azure Managed Identity: Authorize Service-to-Service Requests',
      shortDesc:
        'I recently came across a scenario where I needed to grant service-to-service access between an azure function and an azure web...',
      url: '/blog/2022/azure-managed-identity-authorize-service-requests',
      tags: ['Technical', 'Azure', 'Security'],
      publishDate: new Date(2022, 1, 26),
    },
  ],
}
