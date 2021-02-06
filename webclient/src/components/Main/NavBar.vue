<template>
	<div>
		<b-navbar toggleable="lg" type="dark" variant="info">
			<b-navbar-brand href="#">AirAstana</b-navbar-brand>

			<b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

			<b-collapse id="nav-collapse" is-nav>
				<b-navbar-nav>
					<b-nav-item to="/">Airflights</b-nav-item>
					<b-nav-item to="/about">Link</b-nav-item>
					<b-nav-item href="#" disabled>Disabled</b-nav-item>
				</b-navbar-nav>

				<!-- Right aligned nav items -->
				<b-navbar-nav class="ml-auto">
					<!-- <b-nav-form>
                        <b-form-input
                            size="sm"
                            class="mr-sm-2"
                            placeholder="Search"
                        ></b-form-input>
                        <b-button size="sm" class="my-2 my-sm-0" type="submit"
                            >Search</b-button
                        >
                    </b-nav-form> -->

					<!-- <b-nav-item-dropdown text="Lang" right>
                        <b-dropdown-item href="#">EN</b-dropdown-item>
                        <b-dropdown-item href="#">ES</b-dropdown-item>
                        <b-dropdown-item href="#">RU</b-dropdown-item>
                        <b-dropdown-item href="#">FA</b-dropdown-item>
                    </b-nav-item-dropdown> -->

					<b-nav-item-dropdown v-if="username" right>
						<!-- Using 'button-content' slot -->
						<template #button-content>
							<em>{{ username }}</em>
						</template>
						<b-dropdown-item href="#">Profile</b-dropdown-item>
						<b-dropdown-item @click="signOut"
							>Sign Out</b-dropdown-item
						>
					</b-nav-item-dropdown>

					<b-nav-item v-else>
						<b-button
							@click="openSignInModal($event.target)"
							size="sm"
							class="my-2 my-sm-0"
							type="submit"
						>
							Sign in
						</b-button>
					</b-nav-item>
				</b-navbar-nav>
			</b-collapse>
		</b-navbar>
		<router-view />

		<b-modal
			id="login"
			title="Sign in"
			@ok="login"
            ok-only
		>
			<sign-in @keydown.13="login" />
			<!-- <pre>{{ infoModal.content }}</pre> -->
		</b-modal>
	</div>
</template>

<script>
import SignIn from "../Main/SignIn";
import * as authService from "../../services/auth.service";

export default {
	components: {
		SignIn,
	},
	data() {
		return {
			username: localStorage.username,
		};
	},
	methods: {
		login() {
			this.$root.$emit("sign-in");
		},
		openSignInModal(button) {
			this.$root.$emit("bv::show::modal", "login", button);
		},
		signOut() {
			authService.logOut();
			window.location.reload();
		},
	},
};
</script>
