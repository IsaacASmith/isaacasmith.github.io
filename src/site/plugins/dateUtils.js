import Vue from 'vue'

Vue.filter('formatMonthYear', function (date) {
  if (!date) {
    return ''
  }
  const monthNameShort = date.toLocaleString('en-US', { month: 'short' })
  const year = date.getFullYear()

  return `${monthNameShort} ${year}`
})
