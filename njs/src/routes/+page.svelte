<script lang="ts">
    let { data } = $props();
</script>

{#each data.env.filter(e => e.name.startsWith("ConnectionStrings")) as envy}
    {envy.name} = {envy.value}<br />
{/each}

<style>
    :global(body) {
        font-family: Arial, sans-serif;
    }
</style>