<template>
  <div class="mx-3 md:mx-0">
    <div class="flex flex-row items-center">
      <h1 class="text-3xl">{{ title }}</h1>
    </div>
    <div class="text-md mt-2 text-gray-700">
      {{ publishDate | formatMonthYear }}
    </div>
    <slot></slot>
    <div class="flex flex-row mt-3 text-xs items-center">
      <span class="mr-2 text-sm">Tags: </span>
      <div
        v-for="tag in tags"
        :key="tag"
        class="px-2 py-1 bg-primary text-white mr-2 rounded"
      >
        {{ tag }}
      </div>
    </div>
  </div>
</template>

<script>
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
  },
}
</script>
