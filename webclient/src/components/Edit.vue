<template>
	<b-row align-h="end" class="mb-3 mt-3">
		<b-col lg="12" class="my-1">
			<b-form-group
				label="From"
				label-cols-sm="3"
				label-align-sm="right"
				label-size="sm"
				label-for="fromCity"
				class="mb-0"
			>
				<b-input-group size="sm">
					<b-form-select
						v-model="flight.fromCity.id"
						id="fromCity"
						:options="cities"
						class="w-75"
						value-field="id"
						text-field="name"
					>
					</b-form-select>
				</b-input-group>
			</b-form-group>
		</b-col>
		<b-col lg="12" class="my-1">
			<b-form-group
				label="ToCity"
				label-cols-sm="3"
				label-align-sm="right"
				label-size="sm"
				label-for="toCity"
				class="mb-0"
			>
				<b-input-group size="sm">
					<b-form-select
						v-model="flight.toCity.id"
						id="toCity"
						:options="cities"
						class="w-75"
						value-field="id"
						text-field="name"
					>
					</b-form-select>
				</b-input-group>
			</b-form-group>
		</b-col>
		<b-col lg="12" class="mt-5 my-1">
			<b-form-group
				label="Departure date"
				label-cols-sm="3"
				label-align-sm="right"
				label-size="sm"
				label-for="departureTime"
				class="mt-0"
			>
				<b-form-datepicker
					id="departureTime"
					v-model="departureDate"
					class="mb-2"
				></b-form-datepicker>
				<b-time v-model="departureTime" :locale="locale"></b-time>
			</b-form-group>
		</b-col>
		<b-col lg="12" class="mt-5 my-1">
			<b-form-group
				label="Arrival date"
				label-cols-sm="3"
				label-align-sm="right"
				label-size="sm"
				label-for="arrivalDate"
				class="mt-0"
			>
				<b-form-datepicker
					id="arrivalDate"
					v-model="arrivalDate"
					class="mb-2"
				></b-form-datepicker>
				<b-time v-model="arrivalTime" :locale="locale"></b-time>
			</b-form-group>
		</b-col>
		<b-col lg="12" class="mt-5 my-1">
			<b-form-group
				label="Delay"
				label-cols-sm="3"
				label-align-sm="right"
				label-size="sm"
				label-for="delay"
				class="mt-0"
			>
				<b-form-input
					v-model="flight.delay"
					id="delay"
					name="delay"
					type="number"
					placeholder="set delay (minutes)"
				></b-form-input>
			</b-form-group>
		</b-col>
	</b-row>
</template>

<script>
export default {
	data() {
		return {
			cities: [],

			locale: window.navigator.language,
			oldData: null,
		};
	},
	props: {
		flight: {
			type: Object,
			required: true,
		},
	},
	computed: {
		departureTime: {
			get() {
				return new Date(this.flight.departureTime)
					.toTimeString()
					.slice(0, 8);
			},
			set(value) {
				this.flight.departureTime = this.replaceTimePart(
					this.flight.departureTime,
					value
				);
			},
		},
		arrivalTime: {
			get() {
				return new Date(this.flight.arrivalTime)
					.toTimeString()
					.slice(0, 8);
			},
			set(value) {
				this.flight.arrivalTime = this.replaceTimePart(
					this.flight.arrivalTime,
					value
				);
			},
		},
		departureDate: {
			get() {
				return new Date(this.flight.departureTime);
			},
			set(value) {
				console.log(value);
				this.flight.departureTime = this.replaceDatePart(
					this.flight.departureTime,
					value
				);
			},
		},
		arrivalDate: {
			get() {
				console.log("arrivalDate get", this.flight.arrivalTime);
				return new Date(this.flight.arrivalTime);
			},
			set(value) {
				this.flight.arrivalTime = this.replaceDatePart(
					this.flight.arrivalTime,
					value
				);
				console.log(this.flight.arrivalTime);
			},
		},
	},
	methods: {
		async getCities() {
			try {
				let response = await this.$http.get(`/api/dict/cities`);
				this.cities = response.data.data;
			} catch (error) {
				window.console.error(error);
			}
		},
		replaceTimePart(date, replacement) {
			return (
				date.substr(0, 11) +
				replacement +
				date.substr(11 + replacement.length)
			);
		},
		replaceDatePart(date, replacement) {
			return "" + replacement + date.substr(replacement.length);
		},

		async save() {
			try {
				let response = await this.$httpauth.patch("/api/flights", {
					id: this.flight.id,
					arrivalTime: this.flight.arrivalTime,
					departureTime: this.flight.departureTime,
					fromCityId: this.flight.fromCity.id,
					toCityId: this.flight.toCity.id,
					delay: parseInt(this.flight.delay),
				});
				if (response.status !== 200) {
					this.rollback();
				}
			} catch (error) {
				window.console.error(error);
				this.rollback();
			}
		},
		rollback() {
			this.$set(this.flight.fromCity, "code", this.oldData.fromCity.code);
			this.$set(this.flight.fromCity, "name", this.oldData.fromCity.name);
			this.$set(this.flight.fromCity, "id", this.oldData.fromCity.id);
			this.$set(this.flight.toCity, "id", this.oldData.toCity.id);
			this.$set(this.flight.toCity, "name", this.oldData.toCity.name);
			this.$set(this.flight.toCity, "code", this.oldData.toCity.code);

			this.$set(this.flight, "arrivalTime", this.oldData.arrivalTime);
			this.$set(this.flight, "departureTime", this.oldData.departureTime);
			this.$set(this.flight, "delay", this.oldData.delay);
		},
		clone() {
			this.oldData = {};
			this.oldData.fromCity = {};
			this.oldData.fromCity.code = this.flight.fromCity.code;
			this.oldData.fromCity.name = this.flight.fromCity.name;
			this.oldData.fromCity.id = this.flight.fromCity.id;
			this.oldData.toCity = {};
			this.oldData.toCity.id = this.flight.toCity.id;
			this.oldData.toCity.name = this.flight.toCity.name;
			this.oldData.toCity.code = this.flight.toCity.code;

			this.oldData.arrivalTime = this.flight.arrivalTime;
			this.oldData.departureTime = this.flight.departureTime;
			this.oldData.delay = this.flight.delay;
		},
	},
	watch: {
		"flight.fromCity.id": function (id) {
			let newCity = this.cities.find((c) => c.id === id);
			if (newCity) {
				this.$set(this.flight.fromCity, "name", newCity.name);
				this.$set(this.flight.fromCity, "code", newCity.code);
			}
		},
		"flight.toCity.id": function (id) {
			let newCity = this.cities.find((c) => c.id === id);
			if (newCity) {
				this.$set(this.flight.toCity, "name", newCity.name);
				this.$set(this.flight.toCity, "code", newCity.code);
			}
		},
	},
	async created() {
		await this.getCities();
		let vm = this;
		this.$root.$on("save" + this.flight.id, async function () {
			await vm.save();
		});
		this.clone();
		console.log("oldData", this.oldData);
	},
	beforeDestroy() {
		this.$root.$off("save" + this.flight.id);
	},
};
</script>
