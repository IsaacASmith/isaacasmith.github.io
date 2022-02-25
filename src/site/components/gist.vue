<template>
  <div>
    <iframe
      width="100%"
      :height="height"
      :src="`data:text/html;charset=utf-8;doctype=html,
    <!DOCTYPE html>
    <head><base target='_blank' /></head>
    <body><script src='https://gist.github.com/${gist}.js'></script>
    </body>`"
    ></iframe>
  </div>
</template>

<script>
export default {
  name: 'EmbedGist',
  props: {
    gist: {
      type: String,
      required: true,
    },
    height: {
      type: Number,
      default: 300
    }
  },
}
</script>
