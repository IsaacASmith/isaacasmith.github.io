<template>
  <nav class="py-4 md:py-5 px-4 md:px-6 bg-white flex flex-row justify-between">
    <nuxt-link to="/" class="flex flex-row justify-center items-center">
      <img
        src="~/assets/img/me.jpg"
        width="50"
        alt="Isaac Smith"
        class="mr-4 md:mr-5 inline profile-img"
      />
      <div class="text-primary font-bold inline text-xl md:text-2xl">
        Isaac Smith
        <span class="hidden sm:inline text-sm font-thin ml-1 mb-1">
          // Software Engineer</span
        >
      </div>
    </nuxt-link>
    <span class="float-right flex flex-row justify-center items-center">
      <nuxt-link to="/coming-soon" class="md:mr-3">
        <div
          class="text-primary inline text-base md:text-xl px-2 md:px-3 py-4 hover:underline"
        >
          Blog
        </div>
      </nuxt-link>
      <nuxt-link to="/coming-soon">
        <div class="inline text-base md:text-xl px-2 md:px-3 py-4 hover:underline">
          Projects
        </div>
      </nuxt-link>
    </span>
  </nav>
</template>

<style scoped>
.profile-img {
  border-radius: 100px;
}
</style>
