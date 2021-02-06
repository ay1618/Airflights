<template>
	<b-row align-h="end" class="mb-3 mt-3">
		<b-form-group
			label="Delay"
			label-cols-sm="3"
			label-align-sm="right"
			label-size="sm"
			label-for="delay"
			class="mb-0 pr-5"
		>
			<b-input-group size="sm">
				<b-form-input
					v-model="flight.delay"
					name="delay"
					type="number"
					placeholder="set delay (minutes)"
				></b-form-input>
				<b-input-group-append>
					<b-button @click="save"> Save </b-button>
				</b-input-group-append>
			</b-input-group>
		</b-form-group>
	</b-row>
</template>

<script>
export default {
	data() {
		return {
			delayValue: 0,
		};
	},
	props: {
		flight: {
			type: Object,
			required: true,
		},
	},
	methods: {
		async save() {
			try {
				let response = await this.$httpauth.patch("/api/flights/delayEdit", {
					id: this.flight.id,
					delay: parseInt(this.flight.delay),
				});
				console.log(response);
				this.$emit("hide");
			} catch (error) {
				window.console.error(error);
			}
		},
	},
};
</script>