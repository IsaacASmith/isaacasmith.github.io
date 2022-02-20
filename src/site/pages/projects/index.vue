<template>
  <div>
    <section class="flex flex-col items-center">
      <img
        src="~/assets/img/projects.svg"
        width="90"
        alt="Science beaker"
        class="block"
      />
      <h1 class="text-2xl font-semibold mt-4">Projects</h1>
      <div class="mt-4 mx-3">
        Welcome to the mad science lab! Get a behind the scenes look at what I'm
        building in my free time.
      </div>
    </section>
    <section class="sm:mx-3">
      <div class="grid grid-cols-12 gap-6 mt-8 mx-3 md:mx-0">
        <input
          placeholder="Search projects..."
          class="col-span-12 sm:col-span-4 py-2 px-3 outline-none"
        />
        <input
          placeholder="Filter categories..."
          class="hidden sm:inline col-span-12 sm:col-span-4 py-2 px-3 outline-none"
        />
        <input
          placeholder="Sort by..."
          class="hidden sm:inline col-span-12 sm:col-span-4 py-2 px-3 outline-none"
        />
      </div>
      <div class="grid grid-cols-12 gap-6 mt-8">
        <a
          v-for="project in projectsDefinition.projects"
          :key="project.prodUrl"
          :href="project.prodUrl"
          target="_blank"
          class="col-span-12 sm:col-span-6 bg-white rounded mx-2 sm:mx-0 mb-5 sm:mb-0 shadow"
        >
          <img
            :src="project.thumbnail"
            :alt="project.thumbnailAlt"
            class="block"
          />
          <div class="p-4 sm:p-6">
            <div class="text-xl font-semibold">
              {{ project.title }}
              <img
                src="~/assets/img/external-link.svg"
                alt="External link icon"
                width="15"
                class="inline ml-2 mb-1"
              />
            </div>
            <div class="text-sm text-gray-600 mt-1">
              {{ project.publishDate | formatMonthYear }}
            </div>
            <div class="mt-1">
              {{ project.shortDesc }}
            </div>
            <div class="mt-3 mb-1 text-primary underline">
              <a :href="project.codeUrl" target="_blank"
                >Check out the code
                <img
                  src="~/assets/img/external-link.svg"
                  alt="External link icon"
                  width="12"
                  class="inline ml-2 mb-1"
              /></a>
            </div>
            <div class="flex flex-row flex-wrap mt-3">
              <div
                v-for="tech in project.technologies"
                :key="tech"
                class="px-2 py-1 bg-primary text-white mr-2 rounded text-xs mt-2"
              >
                {{ tech }}
              </div>
            </div>
          </div>
        </a>
      </div>
    </section>
  </div>
</template>

<script>
import projectsDefinition from './projects-definition.js'

export default {
  name: 'ProjectsIndex',
  data: () => ({
    projectsDefinition,
  }),
}
</script>
