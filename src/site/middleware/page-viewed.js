export default function (context) {
  if (process.client) {
      return postPageView(context);
  }
}

function postPageView(context) {
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
          path: context.route.path,
          referrer: document.referrer,
          internalReferrer: context.from.path,
          screenWidth: window.screen.width,
          client: hashCode(getClientId()),
          utmData: {
              medium: urlParams.get('med'),
              source: urlParams.get('src'),
              campaign: urlParams.get('cam'),
              content: urlParams.get('con')
          }
      })
  })
}