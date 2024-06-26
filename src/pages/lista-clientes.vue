<template>
  <q-page class="q-pa-md">
    <div class="q-gutter-md">
      <h1 class="text-h5">Listagem de Clientes</h1>
      <q-card class="q-mt-md">
        <q-card-section>
          <!-- Listagem de entidades legais aqui -->
          <div v-for="(entidade, index) in entidadesLegais" :key="index" class="flex justify-between items-center q-mb-md">
            <q-paragraph class="q-ma-none">{{ entidade.name }}</q-paragraph>
            <div>
              <q-btn @click="editarEntidadeLegal(index)" color="primary" label="Editar" class="q-mr-md" />
              <q-btn @click="removerEntidadeLegal(index)" color="negative" label="Remover" />
            </div>
          </div>
        </q-card-section>
      </q-card>
    </div>
    <!-- Modal de edição da entidade legal -->
    <q-dialog v-model="mostrarModal" persistent class="larger-dialog">
      <q-card>
        <q-card-section>
          <h2 class="text-h6">Editar Entidade Legal</h2>
          <q-input v-model="entidadeLegalEditada.name" label="Nome" />
          <q-input v-model="entidadeLegalEditada.password" label="Senha" type="password" />
          <q-input v-model="entidadeLegalEditada.email" label="E-mail" />
          <q-input v-model="entidadeLegalEditada.phoneNumber" label="Telefone" />
        </q-card-section>
        <q-card-actions align="right">
          <q-btn label="Cancelar" color="negative" @click="fecharModal" />
          <q-btn label="Salvar" color="primary" @click="salvarEntidadeLegal" />
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
      entidadesLegais: [],
      mostrarModal: false,
      entidadeLegalEditada: {
        id: null,
        name: '',
        password: '',
        email: '',
        phoneNumber: ''
      },
      entidadeLegalIndexEditada: null
    };
  },
  mounted() {
    this.carregarEntidadesLegais();
  },
  methods: {
    async carregarEntidadesLegais() {
      try {
        const response = await axios.get('http://localhost:5123/LegalEntity');
        this.entidadesLegais = response.data;
      } catch (error) {
        console.error('Erro ao carregar entidades legais:', error);
      }
    },
    editarEntidadeLegal(index) {
      const { legalEntityId, name, email, password, phoneNumber } = this.entidadesLegais[index];
      this.entidadeLegalEditada = {
        id: legalEntityId,
        name,
        email,
        password,
        phoneNumber
      };
      this.entidadeLegalIndexEditada = index;
      this.mostrarModal = true;
    },
    fecharModal() {
      this.mostrarModal = false;
      this.entidadeLegalEditada = {
        id: null,
        name: '',
        password: '',
        email: '',
        phoneNumber: ''
      };
      this.entidadeLegalIndexEditada = null;
    },
    async salvarEntidadeLegal() {
      if (this.entidadeLegalIndexEditada !== null) {
        try {
          const entidade = this.entidadeLegalEditada;
          await axios.put(`http://localhost:5123/LegalEntity/${entidade.id}`, entidade);
          this.entidadesLegais[this.entidadeLegalIndexEditada] = { ...entidade };
          window.location.reload(); // Recarregar a página após o PUT
        } catch (error) {
          console.error('Erro ao salvar entidade legal:', error);
        }
      }
      this.fecharModal();
    },
    async removerEntidadeLegal(index) {
      const legalEntityId = this.entidadesLegais[index].legalEntityId;
      if (!legalEntityId) {
        console.error('ID da entidade legal não encontrado');
        return;
      }

      try {
        await axios.delete(`http://localhost:5123/LegalEntity/${legalEntityId}`);
        this.entidadesLegais.splice(index, 1);
        console.log(`Entidade legal ${legalEntityId} removida com sucesso`);
        window.location.reload(); // Recarregar a página após o DELETE
      } catch (error) {
        console.error('Erro ao remover entidade legal:', error);
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
