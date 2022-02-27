<template>
    <code class="p-4 bg-grey rounded flex">{{code}}</code>
</template>

<script>
export default {
  name: "CodeBlock",
  props: {
    code: {
      type: String,
      required: true
    }
  }
}
</script>