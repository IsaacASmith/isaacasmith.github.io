<template>
  <footer class="bg-white p-10">
    <div class="max-w-4xl mx-auto px-0 sm:px-8 md:px-12">
      <div class="grid grid-cols-2 gap-8">
        <div class="col-span-2 sm:col-span-1">
          <div class="text-2xl mb-4">Find me on...</div>
          <a href="https://twitter.com/isaac_smith3" target="_blank">
            <div class="mt-2 hover:underline">Twitter</div>
          </a>
          <a href="https://github.com/isaacasmith" target="_blank">
            <div class="mt-2 hover:underline">Github</div>
          </a>
          <a
            href="https://www.linkedin.com/in/isaac-smith-31a3a0149/"
            target="_blank"
          >
            <div class="mt-2 hover:underline">LinkedIn</div>
          </a>
        </div>
        <div class="col-span-2 sm:col-span-1">
          <div class="text-2xl mb-4 mt-6 sm:mt-0">Check out...</div>
          <nuxt-link to="/blog">
            <div class="mt-2 hover:underline">The blog</div>
          </nuxt-link>
          <nuxt-link to="/projects">
            <div class="mt-2 hover:underline">My projects</div>
          </nuxt-link>
        </div>
      </div>
      <div class="mt-16">
        <div class="text-md">Affiliate Disclosure *</div>
        <div class="text-sm">This website may earn a commission if you make a purchase through one of the links on the page.</div>
      </div>
      <div class="mt-16 text-sm">
        Copyright 2022 |
        <nuxt-link to="isaacsmith.us" class="hover:underline"
          >isaacsmith.us</nuxt-link
        >
      </div>
    </div>
  </footer>
</template>
