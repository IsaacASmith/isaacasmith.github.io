<template>
  <div>
    <div class="mx-3 md:mx-0 bg-white p-4 sm:p-8 rounded">
      <h1 class="text-3xl">{{ title }}</h1>
      <div class="flex flex-row items-center mt-2 mb-6 flex-wrap">
        <div class="mr-3 text-md text-gray-700">
          {{ publishDate | formatMonthYear }}
        </div>
        <br />
      </div>
      <div class="flex flex-col items-center mb-4">
        <img :src="thumbnail" class="pb-6" />
      </div>
      <div class="leading-8 text-lg font-normal mb-10">
        <slot></slot>
      </div>
      <Affiliate/>
    </div>
    <div class="px-8 mt-10">
      <div class="text-xl font-bold mb-3">Tags</div>
      <div class="flex flex-row items-center">
        <div
          v-for="tag in tags"
          :key="tag"
          class="px-2 py-1 bg-primary text-white mr-2 rounded text-xs"
        >
          {{ tag }}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Affiliate from './affiliate.vue';

export default {
    props: {
        title: {
            type: String,
            required: true,
        },
        publishDate: {
            type: Date,
            default: () => new Date(),
        },
        tags: {
            type: Array,
            default: () => [],
        },
        thumbnail: {
            type: String,
            default: "",
        },
    },
    components: { Affiliate }
}
</script>
