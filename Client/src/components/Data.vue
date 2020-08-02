// Data.vue



<template>
    <div>
        <versionA title="Variant A"></versionA>
        <versionB title="Variant B"></versionB>
    </div>
</template>
<script>
    import VersionA from './VersionA.vue'
    import VersionB from './VersionB.vue'

    export default {
        components: {
            VersionA,
            VersionB
        }
    }
</script>