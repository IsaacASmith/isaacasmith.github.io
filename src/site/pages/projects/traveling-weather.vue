<template>
  <div>
    <div class="mx-3 md:mx-0 bg-white p-4 sm:p-8 rounded">
      <h1 class="text-3xl">{{ projectDefinition.title }}</h1>
      <div class="flex flex-col items-center mb-6">
        <a href="https://travelingweather.com?src=isaacsite" target="_blank">
          <img
            :src="projectDefinition.thumbnail"
            class="pb-6 border mt-4"
            :alt="projectDefinition.thumbnailAlt"
          />
        </a>
      </div>
      <div class="leading-8 text-lg font-normal">
        <h2 class="font-semibold text-xl">The Origin Story</h2>
        <p>
          While planning a trip to Europe, I came across the need to plan out
          what to pack during my two week trip through 6 different countries. It
          seemed like an issue that anyone who travels needs to deal with, so I
          set out to create a resource that makes it easy to check out the best
          time of year to visit different destinations.
          <a
            class="underline text-blue-700"
            href="https://travelingweather.com?src=isaacsite"
            target="_blank"
            >Explore the weather here.</a
          >
        </p>
        <p class="mt-3">
          I did some cursory keyword research and it turns out that a lot of
          people are looking to discover this same type of weather information.
          My initial strategy targeting some of those keywords to see if I can
          get some traction and validate the idea. Down the road I plan to add a
          full blown weather planner tool to schedule out the different places
          being visited, and recommend what clothes to pack to make sure you're
          covered for each destination.
        </p>
        <h2 class="font-semibold mt-6 text-xl">The Roadmap</h2>
        <p>
          The project is still under active development, but the initial roadmap
          is looking like this:
        </p>
        <p class="mt-4 font-semibold">✔️ Gathering data</p>
        <p class="mt-1">
          I leveraged the US government's NOAA weather data set to aggregate
          monthly weather averages for thousands of weather stations throughout
          the year and align them with nearby cities.
        </p>
        <p class="mt-4 font-semibold">✔️ Building landing pages</p>
        <p class="mt-1">
          To target some low hanging keywords, I built a variety of landing
          pages for monthly weather in popular cities.
        </p>
        <p class="mt-4 font-semibold">🕑 SEO</p>
        <p class="mt-1">
          Building links and improving content to boost SEO to the landing
          pages.
        </p>
        <p class="mt-4 font-semibold">🕑 Planning tool</p>
        <p class="mt-1 mb-8">
          To drive engagement, I plan to build out a full planning tool to
          schedule which cities you're visiting and show the weather throughout
          the trip.
        </p>
        <a
          class="underline text-blue-700"
          href="https://travelingweather.com?src=isaacsite"
          target="_blank"
          >Check out the site</a
        >
      </div>
    </div>
  </div>
</template>

<script>
import projectsDefinition from '@/plugins/projects-definition'

export default {
  head() {
    return {
      title: 'Traveling Weather | Projects',
      meta: [
        {
          hid: 'csp-github-pages-description',
          name: 'description',
          content:
            'While planning a trip to Europe, I came across the need to plan out what to pack during my two week trip through 6 different countries. I built this site to surface up the expected weather for various cities.',
        },
      ],
    }
  },
  computed: {
    projectDefinition() {
      return projectsDefinition.projects.find(
        (project) => project.url === '/projects/traveling-weather'
      )
    },
  },
}
</script>
