<template>
  <q-page class="q-pa-md">
    <div class="q-gutter-md">
      <h1 class="text-h5">Listagem de Clientes</h1>
      <q-card class="q-mt-md">
        <q-card-section>
          <!-- Listagem de clientes aqui -->
          <div v-for="(cliente, index) in clientes" :key="index" class="flex justify-between items-center q-mb-md">
            <q-paragraph class="q-ma-none">{{ cliente.name }}</q-paragraph>
            <div>
              <q-btn @click="editarCliente(index)" color="primary" label="Editar" class="q-mr-md" />
              <q-btn @click="removerCliente(index)" color="negative" label="Remover" />
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
          <q-input v-model="clienteEditado.name" label="Nome" />
          <q-input v-model="clienteEditado.password" label="Senha" type="password" />
          <q-input v-model="clienteEditado.email" label="E-mail" />
          <q-input v-model="clienteEditado.phoneNumber" label="Telefone" />
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
import { defineComponent } from 'vue';
import axios from 'axios';

export default defineComponent({
  name: 'IndexPage',
  data() {
    return {
      clientes: [],
      mostrarModal: false,
      clienteEditado: {
        id: null,
        name: '',
        password: '',
        email: '',
        phoneNumber: ''
      },
      clienteIndexEditado: null
    };
  },
  mounted() {
    this.carregarClientes();
  },
  methods: {
    async carregarClientes() {
      try {
        const response = await axios.get('https://65ff33d3df565f1a6144de0b.mockapi.io/lista-clientes');
        this.clientes = response.data;
      } catch (error) {
        console.error('Erro ao carregar clientes:', error);
      }
    },
    editarCliente(index) {
      this.clienteEditado = { ...this.clientes[index] };
      this.clienteIndexEditado = index;
      this.mostrarModal = true;
    },
    fecharModal() {
      this.mostrarModal = false;
      this.clienteEditado = { id: null, name: '', password: '', email: '', phoneNumber: '' }; // Limpar os dados do cliente editado
      this.clienteIndexEditado = null;
    },
    async salvarCliente() {
      if (this.clienteIndexEditado !== null) {
        try {
          const cliente = this.clienteEditado;
          await axios.put(`https://65ff33d3df565f1a6144de0b.mockapi.io/lista-clientes/${cliente.id}`, cliente);
          this.clientes[this.clienteIndexEditado] = { ...cliente };
        } catch (error) {
          console.error('Erro ao salvar cliente:', error);
        }
      }
      this.fecharModal(); // Fechar o modal após salvar
    },
    async removerCliente(index) {
      const clienteId = this.clientes[index].id;
      try {
        await axios.delete(`https://65ff33d3df565f1a6144de0b.mockapi.io/lista-clientes/${clienteId}`);
        this.clientes.splice(index, 1); // Remove o cliente da lista localmente
        console.log(`Cliente ${clienteId} removido com sucesso`);
      } catch (error) {
        console.error('Erro ao remover cliente:', error);
      }
    }
  }
});
</script>

<style scoped>
/* Estilos personalizados aqui */
.larger-dialog .q-card {
  max-width: 600px; /* Ajuste conforme necessário */
  border-radius: 0px; /* Ajuste conforme necessário */
}
</style>
