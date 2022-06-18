<template>
	<p>
		{{ response }}
	</p>
	<h1>Last 60 seconds</h1>
	<p>
		Feature A count
		{{ featureACount }}
		Feature B count {{ featureBCount }}
	</p>
</template>

<script lang="ts">
import { ref, computed, onMounted } from "vue";

export default {
	name: "HelloWorld",
	props: {},
	setup() {
		const response = ref("");
		const featureACount = ref(0);
		const featureBCount = ref(0);
		let count = 0;

		function fetchData() {
			// I prefer to use fetch
			// you can use use axios as an alternative
			return fetch(
				"https://ndcsample.azurewebsites.net/featuredemo/feature"
			)
				.then(async (res) => {
					response.value = await res.text();
					if (response.value.indexOf("feature A") > -1) {
						featureACount.value++;
					}
					if (response.value.indexOf("feature B") > -1) {
						featureBCount.value++;
					}
					// console.log(`response is ${response.value} - featureACount: ${featureACount.value}, featureB Count: ${featureBCount.value}`);
					if (count > 60) {
						count = 0;
					}
					count++;
				})
				.catch((err) => {
					throw err;
				});
		}

		onMounted(() => {
			setInterval(() => fetchData(), 300);
		});

		return {
			featureACount,
			featureBCount,
			response,
			count,
		};
	},
};
</script>
