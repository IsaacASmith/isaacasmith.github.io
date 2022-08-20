export default {
  // baseURL: 'http://localhost:7071/api',
  baseURL: 'https://fa-metr-personal-site.azurewebsites.net/api',

  appId: '9ce22030-39a7', // Makes client ID tracking unique per app

  sessionStartTime: undefined,
  pageSessionStartTime: undefined,

  initSession() {
    this.sessionStartTime = new Date()
    this.pageSessionStartTime = new Date()
  },

  initPageSession() {
    this.pageSessionStartTime = new Date()
  },

  logPageView(context) {
    const urlParams = new URLSearchParams(window.location.search)

    const isInternalNav = !!context.from.path

    const pageViewedBody = JSON.stringify({
      path: context.route.path,
      referrer: isInternalNav ? '' : document.referrer,
      isInternalNav,
      internalReferrer: context.from.path,
      screenWidth: window.screen.width,
      client: this.getClientId(),
      utmData: isInternalNav ? {} : {
        medium: urlParams.get('med'),
        source: urlParams.get('src'),
        campaign: urlParams.get('cam'),
        content: urlParams.get('con'),
      },
    })
    
    fetch(this.baseURL + '/view', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: pageViewedBody,
    })
  },

  logSessionEnd(context) {
    const ticksOnSession = new Date() - this.sessionStartTime
    const secondsOnSession = Math.abs(ticksOnSession / 1000)
    
    this.logEvent(context, 'session-end', {
      durationSeconds: secondsOnSession,
      onPath: context.route?.path
    })

    this.logPageLeave()
  },

  logPageLeave(context) {
    const ticksOnPage = new Date() - this.pageSessionStartTime
    const secondsOnPage = Math.abs(ticksOnPage / 1000)

    this.logEvent(context, 'page-leave', {
      durationSeconds: secondsOnPage,
      onPath: context.from?.path,
      toPath: context.route?.path
    })

    this.initPageSession()
  },

  logEvent(context, eventName, eventData) {
    
    const eventBody = JSON.stringify({
      path: context.route.path,
      eventName,
      data: eventData,
      client: this.getClientId(),
    })

    fetch(this.baseURL + '/event', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: eventBody,
    })
  },

  getClientId(appId) {
    const hashCode = (s) =>
      s.split('').reduce((a, b) => ((a << 5) - a + b.charCodeAt(0)) | 0, 0)

    return hashCode(
      ''
        .concat(appId)
        .concat('|')
        .concat(window.screen.height)
        .concat('|')
        .concat(window.screen.width)
        .concat('|')
        .concat(window.navigator.language)
        .concat('|')
        .concat(window.navigator.hardwareConcurrency)
        .concat('|')
        .concat(window.navigator.userAgent)
        .concat('|')
        .concat(window.navigator.oscpu)
        .concat('|')
    )
  },
}
