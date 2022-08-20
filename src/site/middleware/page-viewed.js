import sanityMetrics from "~/plugins/sanity-metrics/sanity-metrics";

export default function (context) {
  if (process.client) {
    if (context.from.path) {
      sanityMetrics.logPageLeave(context)
    }
    sanityMetrics.logPageView(context)
  }
}