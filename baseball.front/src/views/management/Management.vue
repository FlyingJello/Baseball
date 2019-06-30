<template>
  <div>
    <b-navbar class="shadow" toggleable="lg" type="dark" variant="primary" fixed="top">
      <b-navbar-brand>Baseball mineur de La Pocatière</b-navbar-brand>
      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav class="ml-auto">
          <b-nav-item-dropdown right no-caret>
            <template slot="button-content"><i class="fas fa-cog fa-lg"></i></template>
            <b-dropdown-item href="#">Mon profil</b-dropdown-item>
            <b-dropdown-item href="#">Mon profil</b-dropdown-item>
            <b-dropdown-item href="#">Mon profil</b-dropdown-item>
            <b-dropdown-divider></b-dropdown-divider>
            <b-dropdown-item href="#">Se déconnecter</b-dropdown-item>
          </b-nav-item-dropdown>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
    <div class="container-fluid">
      <div class="row">
        <b-nav class="d-none d-md-block col-md-2 bg-dark sidebar" sticky="true">
          <div class="text-center py-4 d-none d-xl-block">
            <img class="rounded-circle" src="../../assets/images/img_Simon.jpg" alt="Avatar" style="width:85px;">
            <div class="pt-1">
              <span class="text-white">Jean-Philippe Lévesque</span>
            </div>
            <div>
              <span class="align-top">Administrateur</span>
            </div>
          </div>
          <div class="sidebar-sticky">
            <b-nav-item active>
              <i class="fas fa-th-large fa-fw mr-3"></i>
              <a class="d-none d-xl-inline">Tableau de bord</a>
            </b-nav-item>
          </div>
        </b-nav>
        <main role="main" class="col-md-10 col-lg-10 ml-sm-auto px-4">
            <router-view/>
        </main>
      </div>
    </div>
  </div>
</template>
