<template>
	<b-container fluid class="my-1">
		<!-- User Interface controls -->
		<b-row class="mb-3 mt-3">
			<b-col lg="6" class="my-1">
				<b-form-group
					label="From"
					label-cols-sm="3"
					label-align-sm="right"
					label-size="sm"
					label-for="sortBySelect"
					class="mb-0"
				>
					<b-input-group size="sm">
						<b-form-select
							v-model="fromCity"
							id="sortBySelect"
							:options="filteredCities('toCity')"
							class="w-75"
							value-field="id"
							text-field="name"
						>
						</b-form-select>
					</b-input-group>
				</b-form-group>
			</b-col>

			<b-col lg="6" class="my-1">
				<b-form-group
					label="to"
					label-cols-sm="3"
					label-align-sm="right"
					label-size="sm"
					label-for="initialSortSelect"
					class="mb-0"
				>
					<b-form-select
						v-model="toCity"
						id="initialSortSelect"
						size="sm"
						:options="filteredCities('fromCity')"
						value-field="id"
						text-field="name"
					></b-form-select>
				</b-form-group>
			</b-col>

			<b-col lg="6" class="mt-5 my-1">
				<b-form-group
					label="Departure date"
					label-cols-sm="3"
					label-align-sm="right"
					label-size="sm"
					label-for="filterInput"
					class="mt-0"
				>
					<b-form-datepicker
						id="example-datepicker"
						v-model="departureDate"
						class="mb-2"
					></b-form-datepicker>
				</b-form-group>
			</b-col>

			<b-col lg="6" class="mt-5 my-1">
				<b-form-group
					label="Departure time"
					label-cols-sm="3"
					label-align-sm="right"
					label-size="sm"
					label-for="filterInput"
					class="mt-0"
				>
					<vue-slider
						class="mt-1 mr-5"
						v-model="rangeDeprtureValue"
						:enable-cross="enableCross"
						:min="min"
						:max="max"
						:min-range="minRange"
						:tooltip="'always'"
						:interval="step"
						:tooltip-formatter="getTimeString"
						:tooltip-placement="['top', 'bottom']"
						@change="getFiltered"
					></vue-slider>
				</b-form-group>
			</b-col>
		</b-row>
		<b-row align-h="start">
			<b-col lg="1" class="my-1 pr-5">
				<b-button
					v-if="isAdmin"
					size="md"
					@click="openCreateModal($event.target)"
				>
					Create
				</b-button>
			</b-col>
		</b-row>
		<!-- Main table element -->
		<b-table
			show-empty
			small
			stacked="md"
			:items="flights"
			:fields="fields"
			:current-page="currentPage"
			:per-page="perPage"
			:filter="filter"
			:filter-included-fields="filterOn"
			:sort-by.sync="sortBy"
			:sort-desc.sync="sortDesc"
			:sort-direction="sortDirection"
			@filtered="onFiltered"
		>
			<!-- <template #cell(name)="row">
				{{ row.value.first }} {{ row.value.last }}
			</template> -->

			<template #cell(actions)="row">
				<!-- <b-button
					size="sm"
					@click="info(row.item, row.index, $event.target)"
					class="mr-1"
				>
					Edit
				</b-button> -->
				<b-button
					v-if="isAdmin"
					size="sm"
					@click="goToEdit(row.item, row.item.id, $event.target)"
					class="mr-1"
				>
					Edit
				</b-button>
				<b-button
					v-if="isAdmin || isModerator"
					size="sm"
					@click="row.toggleDetails"
				>
					Change delay
				</b-button>
			</template>

			<template #row-details="row">
				<b-card>
					<set-delay :flight="row.item" @hide="row.toggleDetails" />
					<!-- <ul>
						<li v-for="(value, key) in row.item" :key="key">
							{{ key }}: {{ value }}
						</li>
					</ul> -->
				</b-card>
			</template>
		</b-table>

		<b-row align-h="end">
			<b-col sm="5" md="3">
				<b-form-group
					label="Per page"
					label-cols-sm="5"
					label-cols-md="4"
					label-cols-lg="3"
					label-align-sm="right"
					label-size="sm"
					label-for="perPageSelect"
					class="mb-0"
				>
					<b-form-select
						v-model="perPage"
						id="perPageSelect"
						size="sm"
						:options="pageOptions"
						style="width: 90px"
					></b-form-select>
				</b-form-group>
			</b-col>
			<b-col cols="4">
				<b-pagination
					v-model="currentPage"
					:total-rows="totalRows"
					:per-page="perPage"
					align="fill"
					size="sm"
					class="my-0"
				></b-pagination>
			</b-col>
		</b-row>

		<!-- Info modal -->
		<b-modal
			:id="infoModal.id"
			:title="infoModal.title"
			ok-only
			@ok="save(infoModal.content.id)"
			@hide="resetInfoModal"
		>
			<edit v-if="infoModal.content" :flight="infoModal.content" />
			<!-- <pre>{{ infoModal.content }}</pre> -->
		</b-modal>
		<b-modal id="modalCreate" title="Create" ok-only @ok="createFlight()">
			<create />
			<!-- <pre>{{ infoModal.content }}</pre> -->
		</b-modal>
	</b-container>
</template>

<script>
import VueSlider from "vue-slider-component";
import "vue-slider-component/theme/default.css";
import roles from "../mixins/roles.mixin";

import * as dateHelper from "../helpers/date.helper";

import SetDelay from "./SetDelay";
import Edit from "./Edit";
import Create from "./Create";

export default {
	components: {
		VueSlider,
		SetDelay,
		Edit,
		Create,
	},
	mixins: [roles],
	data() {
		return {
			fields: [
				{
					key: "id",
					label: "ID",
					sortable: true,
					sortDirection: "desc",
				},
				{
					key: "fromCity.name",
					label: "From",
					sortable: true,
					sortDirection: "desc",
				},
				{
					key: "toCity.name",
					label: "To",
					sortable: true,
					sortDirection: "desc",
				},
				{
					key: "departureTime",
					label: "Departure time",
					sortable: true,
					formatter: (value /*, key, item */) => {
						return new Date(value).toLocaleString();
					},
					class: "text-center",
					sortDirection: "desc",
				},
				{
					key: "arrivalTime",
					label: "Arrival time",
					sortable: true,
					formatter: (value /*, key, item */) => {
						return new Date(value).toLocaleString();
					},
					class: "text-center",
					sortDirection: "desc",
				},
				{
					key: "delay",
					label: "Delay time",
					sortable: true,
					class: "text-center",
					sortDirection: "desc",
				},

				{ key: "actions", label: "Actions" },
			],
			totalRows: 1,
			currentPage: 1,
			perPage: 10,
			pageOptions: [5, 10, 15, { value: 100, text: "Show a lot" }],
			sortBy: "",
			sortDesc: false,
			sortDirection: "asc",
			filter: null,
			filterOn: [],
			infoModal: {
				id: "info-modal",
				title: "",
				content: "",
			},

			//------
			cities: [],
			fromCity: null,
			toCity: null,
			flights: [],

			rangeDeprtureValue: [0, 24 * 60 - 1],
			rangeArrivalValue: [0, 24 * 60],
			min: 0,
			max: 1439,
			minRange: 30,
			step: 1,
			enableCross: false,

			departureDate: dateHelper.curOnlyDateTemplate(),

			forEdit: null,
		};
	},
	computed: {
		sortOptions() {
			// Create an options list from our fields
			return this.fields
				.filter((f) => f.sortable)
				.map((f) => {
					return { text: f.label, value: f.key };
				});
		},
	},
	mounted() {
		// Set the initial number of items
		this.totalRows = this.flights.length;
	},
	methods: {
		filteredCities(from) {
			if (this[from]) {
				return this.cities.filter((c) => c.id !== this[from]);
			}
			return this.cities;
		},
		info(item, index, button) {
			this.infoModal.title = `Edit: ${index}`;
			this.infoModal.content = JSON.stringify(item, null, 2);
			this.$root.$emit("bv::show::modal", this.infoModal.id, button);
		},
		resetInfoModal() {
			this.infoModal.title = "";
			this.infoModal.content = null;
		},
		onFiltered(filteredItems) {
			// Trigger pagination to update the number of buttons/pages due to filtering
			this.totalRows = filteredItems.length;
			this.currentPage = 1;
		},

		goToEdit(item, index, button) {
			this.infoModal.title = `Row index: ${index}`;
			this.infoModal.content = item;
			this.$root.$emit("bv::show::modal", this.infoModal.id, button);
		},

		openCreateModal(button) {
			this.$root.$emit("bv::show::modal", "modalCreate", button);
		},

		//---------
		async getCities() {
			try {
				let response = await this.$http.get(`/api/dict/cities`);
				this.cities = response.data.data;
				this.cities.unshift({id: 0, name: ''});
			} catch (error) {
				window.console.error(error);
			}
		},
		async getFlights() {
			try {
				let response = await this.$http.get(`/api/flights`);
				this.flights = response.data.data;
			} catch (error) {
				window.console.error(error);
			}
		},
		getTimeString(value) {
			// return new Date(`0001-01-01T${value < 10 ? `0${value}` : value }:00:00`).toLocaleTimeString();

			return new Date(this.getDateTimeString(value)).toLocaleTimeString();
		},
		getDateTimeString(value) {
			// return new Date(`0001-01-01T${value < 10 ? `0${value}` : value }:00:00`).toLocaleTimeString();

			let hours = parseInt(value / 60);
			let mins = value % 60;
			let hoursStrPart = hours < 10 ? `0${hours}` : hours;
			let minsStrPart = mins < 10 ? `0${mins}` : mins;
			return `0001-01-01T${hoursStrPart}:${minsStrPart}:00`;
		},
		mergeFormatString(value1, value2) {
			return `${this.getTimeString(value1)} - ${this.getTimeString(
				value2
			)}`;
		},
		save(id) {
			this.$root.$emit("save" + id);
		},

		async createFlight() {
			this.$root.$emit("create");
			await this.getFiltered();
		},

		async getFiltered(initiator) {
			let query = ``;
			query += this.fromCity ? `From=${this.fromCity}` : ``;
			query += this.toCity ? `&To=${this.toCity}` : ``;
			if (this.departureDate) {
				let from = this.replaceDatePart(
					this.getDateTimeString(this.rangeDeprtureValue[0]),
					this.departureDate
				);
				let until = this.replaceDatePart(
					this.getDateTimeString(this.rangeDeprtureValue[1]),
					this.departureDate
				);
				query += `&DepartureTimeFrom=${from}`;
				query += `&DepartureTimeUntil=${until}`;
			}
			if (query !== "" || initiator === "create") {
				try {
					let response = await this.$http.get(
						`/api/flights/filter?${query}`
					);
					this.flights = response.data.data;
				} catch (error) {
					window.console.error(error);
				}
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
	},
	watch: {
		fromCity: async function () {
			await this.getFiltered();
		},
		toCity: async function () {
			await this.getFiltered();
		},
		departureDate: async function () {
			await this.getFiltered();
		},
	},
	async created() {
		await this.getCities();
		// await this.getFlights();
		await this.getFiltered();
		this.totalRows = this.flights.length;
		let vm = this;
		this.$root.$on("refresh-flights", async function (reason) {
			await vm.getFiltered(reason);
		});
	},
};
</script>

<style>
</style>