let pageViewEndpoint = 'http://localhost:7071/api/view'

console.log(getClientId())
console.log(hashCode(getClientId()))

fetch(pageViewEndpoint, {
  method: "POST",
  headers: {
    'Content-Type': 'application/json'
  },
  body: JSON.stringify({
    path: window.location.pathname,
    pageTitle: document.title,
    referrer: document.referrer,
    clientHash: hashCode(getClientId())
  })
})

const getClientId = () => ''
  .concat('3286f0be-14f7').concat('|')
  .concat(window.screen.height).concat('|')
  .concat(window.screen.width).concat('|')
  .concat(window.navigator.language).concat('|')
  .concat(window.navigator.hardwareConcurrency).concat('|')
  .concat(window.navigator.userAgent).concat('|')
  .concat(window.navigator.oscpu).concat('|')

const hashCode = s => s.split('').reduce((a, b) => (((a << 5) - a) + b.charCodeAt(0)) | 0, 0)