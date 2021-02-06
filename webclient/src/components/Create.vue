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
						v-model="fromCityId"
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
						v-model="toCityId"
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
					v-model="delay"
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

import * as dateHelper from '../helpers/date.helper'; 


export default {
	data() {
		return {
			cities: [],

			locale: window.navigator.language,
			oldData: null,

			fromCityId: 0,
			toCityId: 0,
			delay: 0,

			arrivalTimeD: dateHelper.curDateTemplate(),
			departureTimeD: dateHelper.curDateTemplate(),
		};
	},
	computed: {
		departureTime: {
			get() {
				return new Date(this.departureTimeD).toTimeString().slice(0, 8);
			},
			set(value) {
				this.departureTimeD = this.replaceTimePart(
					this.departureTimeD,
					value
				);
			},
		},
		arrivalTime: {
			get() {
				return new Date(this.arrivalTimeD).toTimeString().slice(0, 8);
			},
			set(value) {
				this.arrivalTimeD = this.replaceTimePart(
					this.arrivalTimeD,
					value
				);
			},
		},
		departureDate: {
			get() {
				return new Date(this.departureTimeD);
			},
			set(value) {
				console.log(value);
				this.departureTimeD = this.replaceDatePart(
					this.departureTimeD,
					value
				);
			},
		},
		arrivalDate: {
			get() {
				console.log("arrivalDate get", this.arrivalTimeD);
				return new Date(this.arrivalTimeD);
			},
			set(value) {
				this.arrivalTimeD = this.replaceDatePart(
					this.arrivalTimeD,
					value
				);
				console.log(this.arrivalTimeD);
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
			console.log("date", date);
			console.log("replacement", replacement);
			return "" + replacement + date.substr(replacement.length);
		},

		async save() {
			try {
				let response = await this.$httpauth.put("/api/flights", {
					arrivalTime: this.arrivalTimeD,
					departureTime: this.departureTimeD,
					fromCityId: this.fromCityId,
					toCityId: this.toCityId,
				});
				console.log(response);
			} catch (error) {
				window.console.error(error);
			}
		},
	},
	watch: {
		"fromCity.id": function (id) {
			let newCity = this.cities.find((c) => c.id === id);
			if (newCity) {
				this.$set(this.fromCity, "name", newCity.name);
				this.$set(this.fromCity, "code", newCity.code);
			}
		},
		"toCity.id": function (id) {
			let newCity = this.cities.find((c) => c.id === id);
			if (newCity) {
				this.$set(this.toCity, "name", newCity.name);
				this.$set(this.toCity, "code", newCity.code);
			}
		},
	},
	async created() {
		await this.getCities();
		let vm = this;
		this.$root.$on("create", async function () {
			await vm.save();
			vm.$root.$emit("refresh-flights", "create");
		});
		this.oldData = this.flight;
		console.log(new Date().toLocaleString());
	},
	beforeDestroy() {
		this.$root.$off("create");
	},
};
</script>
