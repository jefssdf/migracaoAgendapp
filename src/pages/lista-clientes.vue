<template>
  <q-page class="q-pa-md">
    <div class="q-gutter-md">
      <h1 class="text-h5">Listagem de Clientes</h1>
      <q-card class="q-mt-md">
        <q-card-section>
          <div v-for="(cliente, index) in clientes" :key="index" class="flex justify-between items-center q-mb-md">
            <q-paragraph class="q-ma-none">{{ cliente.nome }}</q-paragraph>
            <div>
              <q-btn @click="editarCliente(index)" color="primary" label="Editar" class="q-mr-md" />
              <q-btn @click="removerCliente(cliente.id)" color="negative" label="Remover" />
            </div>
          </div>
        </q-card-section>
      </q-card>
    </div>
    <!-- Modal de edição do cliente -->
    <q-dialog v-model="mostrarModal" persistent class="larger-dialog">
      <q-card>
        <q-card-section>
          <h2 class="text-h6">Editar Cliente</h2>
          <q-input v-model="clienteEditado.nome" label="Nome" />
          <q-input v-model="clienteEditado.senha" label="Senha" type="password" />
          <q-input v-model="clienteEditado.cnpj" label="CNPJ" />
          <q-input v-model="clienteEditado.email" label="E-mail" />
          <q-input v-model="clienteEditado.telefone" label="Telefone" />
          <!-- Adicione aqui os campos que deseja editar -->
        </q-card-section>
        <q-card-actions align="right">
          <q-btn label="Cancelar" color="negative" @click="fecharModal" />
          <q-btn label="Salvar" color="primary" @click="salvarCliente" />
        </q-card-actions>
      </q-card>
    </q-dialog>
  </q-page>
</template>

<script>
import { defineComponent } from 'vue'
import axios from 'axios'

export default defineComponent({
  name: 'IndexPage',
  data () {
    return {
      clientes: [],
      mostrarModal: false,
      clienteEditado: {
        name: '',
        email: '',
        password: '',
        phoneNumber: '',
        address: '',
        cnpj: '',
        socialName: ''
        // Adicione outros campos do cliente aqui conforme necessário
      },
      clienteIndexEditado: null
    }
  },
  mounted () {
    this.getClientes()
  },
  methods: {
    async getClientes () {
      try {
        const response = await axios.get('http://localhost:5123/LegalEntity')
        this.clientes = response.data
        console.log(response.data)
        console.log(this.clientes)
      } catch (error) {
        console.error('Erro ao buscar clientes:', error)
      }
    },
    editarCliente (index) {
      this.clienteEditado = { ...this.clientes[index] }
      this.clienteIndexEditado = index
      this.mostrarModal = true
    },
    fecharModal () {
      this.mostrarModal = false
      this.clienteEditado = {
        name: '',
        email: '',
        password: '',
        phoneNumber: '',
        address: '',
        cnpj: '',
        socialName: ''
      } // Limpar os dados do cliente editado
      this.clienteIndexEditado = null
    },
    async salvarCliente () {
      try {
        // Aqui você pode implementar a lógica para salvar as alterações do cliente
        console.log('Salvar alterações do cliente:', this.clienteEditado)
        // Por exemplo, atualizar o cliente na lista:
        if (this.clienteIndexEditado !== null) {
          const response = await axios.put(`http://localhost:5051/persons/LegalPerson/${this.clienteEditado.id}`, this.clienteEditado)
          this.clientes[this.clienteIndexEditado] = response.data
        }
        this.fecharModal() // Fechar o modal após salvar
      } catch (error) {
        console.error('Erro ao salvar cliente:', error)
      }
    },
    async removerCliente (id) {
      try {
        // Lógica para remover cliente
        console.log('Remover cliente com ID:', id)
        await axios.delete(`http://localhost:5051/persons/LegalPerson/${id}`)
        this.clientes = this.clientes.filter(cliente => cliente.id !== id)
      } catch (error) {
        console.error('Erro ao remover cliente:', error)
      }
    }
  }
})
</script>

<style scoped>
/* Estilos personalizados aqui */
.larger-dialog .q-card {
  max-width: 600px; /* Ajuste conforme necessário */
  border-radius: 0px; /* Ajuste conforme necessário */
}
</style>
