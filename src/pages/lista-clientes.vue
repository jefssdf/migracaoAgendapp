<template>
    <q-page class="q-pa-md">
      <div class="q-gutter-md">
        <h1 class="text-h5">Listagem de Clientes</h1>
        <q-card class="q-mt-md">
          <q-card-section>
            <!-- Listagem de clientes aqui -->
            <div v-for="(cliente, index) in clientes" :key="index" class="flex justify-between items-center q-mb-md">
              <q-paragraph class="q-ma-none">{{ cliente.nome }}</q-paragraph>
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
  import { defineComponent } from 'vue';
  
  export default defineComponent({
    name: 'IndexPage',
    data() {
      return {
        clientes: [
          { nome: 'Jailson T.', senha: 'senha123', cnpj: '12345678901234', email: 'jailson@example.com', telefone: '123456789' },
          { nome: 'Ricardo P.', senha: 'senha456', cnpj: '98765432109876', email: 'ricardo@example.com', telefone: '987654321' },
          { nome: 'Cliente 3', senha: 'senha789', cnpj: '55556666777788', email: 'cliente3@example.com', telefone: '555566667' }
          // Adicione seus clientes aqui ou carregue de uma fonte de dados
        ],
        mostrarModal: false,
        clienteEditado: {
          nome: '',
          senha: '',
          cnpj: '',
          email: '',
          telefone: ''
          // Adicione outros campos do cliente aqui conforme necessário
        },
        clienteIndexEditado: null
      };
    },
    methods: {
      editarCliente(index) {
        this.clienteEditado = { ...this.clientes[index] };
        this.clienteIndexEditado = index;
        this.mostrarModal = true;
      },
      fecharModal() {
        this.mostrarModal = false;
        this.clienteEditado = { nome: '', senha: '', cnpj: '', email: '', telefone: '' }; // Limpar os dados do cliente editado
        this.clienteIndexEditado = null;
      },
      salvarCliente() {
        // Aqui você pode implementar a lógica para salvar as alterações do cliente
        console.log('Salvar alterações do cliente:', this.clienteEditado);
        // Por exemplo, atualizar o cliente na lista:
        if (this.clienteIndexEditado !== null) {
          this.clientes[this.clienteIndexEditado] = { ...this.clienteEditado };
        }
        this.fecharModal(); // Fechar o modal após salvar
      },
      removerCliente(index) {
        // Lógica para remover cliente
        console.log('Remover cliente:', this.clientes[index]);
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
  