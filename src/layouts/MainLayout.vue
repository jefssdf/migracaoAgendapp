<template>
  <q-layout view="lHh Lpr lFf">
    <q-header class="custom-header" elevated>
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="toggleLeftDrawer"
        />

        <q-btn
          flat
          dense
          round
          icon="home"
          aria-label="Home"
          @click="$router.push('/index')"
        />

        <q-toolbar-title>
          Agenda App
        </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-drawer
      v-model="leftDrawerOpen"
      show-if-above
      bordered
    >
      <q-list>
        <q-item-label
          header
        >
          Menu
        </q-item-label>

        <EssentialLink
          v-for="link in linksList"
          :key="link.title"
          v-bind="link"
        />

        <q-item clickable @click="$router.push('/cadastro-cliente')">
          <q-item-section>
            <q-item-label>Cadastro de Cliente</q-item-label>
          </q-item-section>
        </q-item>

        <q-item clickable @click="$router.push('/lista-clientes')">
          <q-item-section>
            <q-item-label>Lista de Clientes</q-item-label>
          </q-item-section>
        </q-item>
      </q-list>
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import { defineComponent, ref } from 'vue'
import EssentialLink from 'components/EssentialLink.vue'

const linksList = [

]

export default defineComponent({
  name: 'MainLayout',

  components: {
    EssentialLink
  },

  setup () {
    const leftDrawerOpen = ref(false)

    return {
      linksList,
      leftDrawerOpen,
      toggleLeftDrawer () {
        leftDrawerOpen.value = !leftDrawerOpen.value
      }
    }
  }
})
</script>

<style>
.custom-header {
  background-color: green; /* Altere para a cor verde que desejar */
}
</style>
