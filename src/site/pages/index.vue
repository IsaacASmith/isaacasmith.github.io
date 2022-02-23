<template>
  <div>
    <div class="flex flex-row justify-center items-center">
      <img
        src="~/assets/img/me.jpg"
        width="250"
        height="250"
        alt="Headshot of Isaac Smith"
        class="mr-4 md:mr-5 inline profile-img"
      />
    </div>
    <section
      class="flex flex-col justify-center items-center mt-4 sm:max-w-sm max-w-xl m-auto"
    >
      <h1 class="text-3xl">Hi! I'm Isaac.</h1>
      <div class="mt-1">I flip bits to solve problems.</div>
    </section>
    <section class="grid grid-cols-12 gap-8 mt-10 sm:mt-20 sm:mx-3">
      <nuxt-link
        to="/blog"
        class="col-span-12 sm:col-span-6 bg-white rounded p-4 sm:p-6 pt-12 flex flex-col items-center mx-2 sm:mx-0"
      >
        <img
          src="~/assets/img/blog.svg"
          width="90"
          alt="Book icon"
          class="block"
        />
        <div class="text-xl font-semibold mt-5">The Blog</div>
        <div class="mt-4">
          I write about all things software development, the relationship
          between technology and business, and continual improvement.
        </div>
      </nuxt-link>
      <nuxt-link
        to="/projects"
        class="col-span-12 sm:col-span-6 bg-white rounded p-4 sm:p-6 pt-12 flex flex-col items-center mx-2 sm:mx-0"
      >
        <img
          src="~/assets/img/projects.svg"
          width="100"
          alt="Science beaker icon"
          class="block"
        />
        <div class="text-xl font-semibold mt-5">Projects</div>
        <div class="mt-4">
          Enter the mad science lab. Get a behind the scenes look at what I'm
          building in my free time.
        </div>
      </nuxt-link>
    </section>
  </div>
</template>

<script>
export default {
  name: 'IndexPage',
  head() {
    return {
      title: 'Isaac Smith | Home',
      meta: [
        {
          hid: 'blog-description',
          name: 'description',
          content:
            "Hi! I'm Isaac. I'm a software engineering consultant in Sioux Falls, South Dakota",
        },
      ],
    }
  },
}
</script>

<style scoped>
.profile-img {
  border-radius: 250px;
  border: 2px solid white;
}
</style>
