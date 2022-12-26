<script>
	import Header from './Header.svelte';
	import '../app.postcss';
</script>

<div class="app">
	<Header />

	<main>
		<slot />
	</main>

	<footer />
</div>

<style lang="postcss">
</style>
