<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated class="toolbar-green">
      <q-toolbar color="#24cb53">
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="toggleLeftDrawer"
          class="menu-icon"
        />

        <q-toolbar-title style="color: white;">
          Agenda App
        </q-toolbar-title>

        <!-- Botão de Logout -->
        <q-btn
          flat
          dense
          round
          icon="logout"
          aria-label="Logout"
          class="menu-icon"
          style="color: white;"
          @click="logout"
        />
      </q-toolbar>
    </q-header>

    <q-drawer
      v-model="leftDrawerOpen"
      show-if-above
      bordered
      class="drawer-green"
    >
    <q-item-label
          header
          class="menu-header"
          style="font-size: 20px;"
        >
          Menus
        </q-item-label>
      <q-list>
        <q-item clickable @click="goToDashboard">
          <q-item-section>
            <q-item-label>
              <q-icon name="dashboard" /> <!-- Ícone de dashboard -->
              Dashboard
            </q-item-label>
          </q-item-section>
        </q-item>

        <q-item clickable @click="goToCadastroCliente">
          <q-item-section>
            <q-item-label>
              <q-icon name="person_add" /> <!-- Ícone de cadastro de cliente -->
              Cadastro de Cliente
            </q-item-label>
          </q-item-section>
        </q-item>

        <q-item clickable @click="goToListaClientes">
          <q-item-section>
            <q-item-label>
              <q-icon name="library_books" /> <!-- Ícone de lista de clientes -->
              Lista de Clientes
            </q-item-label>
          </q-item-section>
        </q-item>
      </q-list>
      <q-img src="https://i.ibb.co/CzzsksM/logo.png" alt="Logo"
       style="width: 350px; height: auto; margin-top: auto; position: absolute; bottom: -35px; left: 61%; transform: translateX(-50%);" />

    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import { defineComponent, ref } from 'vue'
import { useRouter } from 'vue-router'

export default defineComponent({
  name: 'MainLayout',

  setup () {
    const leftDrawerOpen = ref(false)
    const router = useRouter()

    const toggleLeftDrawer = () => {
      leftDrawerOpen.value = !leftDrawerOpen.value
    }

    const goToDashboard = () => {
      router.push('/index')
      toggleLeftDrawer()
    }

    const goToCadastroCliente = () => {
      router.push('/cadastro-cliente')
      toggleLeftDrawer()
    }

    const goToListaClientes = () => {
      router.push('/lista-clientes')
      toggleLeftDrawer()
    }

    const logout = () => {
      // Aqui você pode adicionar a lógica para limpar a sessão ou realizar o logout
      // Redirecionar para a tela de login, por exemplo:
      router.push('/login')
    }

    return {
      leftDrawerOpen,
      toggleLeftDrawer,
      goToDashboard,
      goToCadastroCliente,
      goToListaClientes,
      logout
    }
  }
})
</script>

<style>
.toolbar-green { background-color: green; }
.menu-icon { color: white; }
.drawer-green { background-color: #ebebeb; color: rgb(0, 0, 0); }
.q-toolbar {
  display: flex;
  justify-content: flex-start;
  align-items: center;
}
</style>
