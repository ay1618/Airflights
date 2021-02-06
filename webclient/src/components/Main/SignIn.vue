<template>
	<b-row align-h="end" class="mb-3 mt-3">
		<b-col lg="12" class="mt-5 my-1">
			<b-form-group
				label="Login"
				label-cols-sm="3"
				label-align-sm="right"
				label-size="sm"
				label-for="login"
				class="mt-0"
			>
				<b-form-input
					v-model="login"
					id="delay"
					name="login"
					type="text"
					placeholder="set delay (minutes)"
                    @keydown.enter="enter"
				></b-form-input>
			</b-form-group>
		</b-col>
		<b-col lg="12" class="mt-5 my-1">
			<b-form-group
				label="Password"
				label-cols-sm="3"
				label-align-sm="right"
				label-size="sm"
				label-for="password"
				class="mt-0"
			>
				<b-form-input
					v-model="password"
					id="password"
					name="password"
					type="password"
					placeholder="set delay (minutes)"
					@keydown.enter="enter"
				></b-form-input>
			</b-form-group>
		</b-col>
	</b-row>
</template>

<script>
import * as authService from "../../services/auth.service";
export default {
	data() {
		return {
			login: "",
			password: "",
		};
	},
	methods: {
		async signIn() {
			try {
				let response = await this.$http.post("/api/Auth/authenticate", {
					login: this.login,
					password: this.password,
				});
				console.log(response);
				if (response.data.data) {
					authService.setAuth(response.data.data);
					window.location.reload();
				}
			} catch (error) {
				window.console.error(error);
			}
		},
		enter() {
			this.$emit(
				"keydown",
				new KeyboardEvent("keydown", { keyCode: 13 })
			);
		},
	},
	created() {
		let vm = this;
		this.$root.$on("sign-in", async function () {
			await vm.signIn();
		});
	},
};
</script>

<style>
</style>