<template>
  <div class="q-pa-md">
    <q-table
      flat bordered
      title="Dashboard - Clientes"
      :rows="rows"
      :columns="columns"
      row-key="name"
    >
      <template v-slot:body="props">
        <q-tr :props="props" @click="onRowClick(props.row)">
          <q-td key="name" :props="props">
            {{ props.row.name }}
          </q-td>
          <q-td key="agendado" :props="props">
            <q-badge color="green">
              {{ props.row.agendado }}
            </q-badge>
          </q-td>
          <q-td key="finalizado" :props="props">
            <q-badge color="blue">
              {{ props.row.finalizado }}
            </q-badge>
          </q-td>
          <q-td key="aguardandoPagamento" :props="props">
            <q-badge color="orange">
              {{ props.row.aguardandoPagamento }}
            </q-badge>
          </q-td>
          <q-td key="cancelado" :props="props">
            <q-badge color="red">
              {{ props.row.cancelado }}
            </q-badge>
          </q-td>
        </q-tr>
      </template>
    </q-table>
  </div>
</template>

<script>
import { ref, onMounted } from 'vue'
import { useQuasar } from 'quasar'

export default {
  setup() {
    const rows = ref([])
    const columns = [
      {
        name: 'name',
        required: true,
        label: 'Clientes',
        align: 'left',
        field: row => row.name,
        format: val => `${val}`,
        sortable: true
      },
      { name: 'agendado', label: 'Agendado', field: 'agendado', sortable: true },
      { name: 'finalizado', label: 'Finalizado', field: 'finalizado', sortable: true },
      { name: 'aguardandoPagamento', label: 'Aguardando Pagamento', field: 'aguardandoPagamento', sortable: true },
      { name: 'cancelado', label: 'Cancelado', field: 'cancelado', sortable: true }
    ]

    const fetchLegalEntities = async () => {
      try {
        const response = await fetch('http://localhost:5123/LegalEntity')
        const data = await response.json()
        return data
      } catch (error) {
        console.error('Error fetching legal entities:', error)
      }
    }

    const fetchScheduling = async (legalEntityId) => {
      try {
        const response = await fetch(`http://localhost:5123/Scheduling/legalEntity/${legalEntityId}`)
        const data = await response.json()
        return data
      } catch (error) {
        console.error(`Error fetching scheduling for legalEntityId ${legalEntityId}:`, error)
      }
    }

    const populateTable = async () => {
      const legalEntities = await fetchLegalEntities()
      const rowsData = []

      for (const entity of legalEntities) {
        const schedulings = await fetchScheduling(entity.legalEntityId)
        const agendado = schedulings.filter(s => s.schedulingStatusName === 'agendado').length
        const finalizado = schedulings.filter(s => s.schedulingStatusName === 'finalizado').length
        const aguardandoPagamento = schedulings.filter(s => s.schedulingStatusName === 'aguardando pagamento').length
        const cancelado = schedulings.filter(s => s.schedulingStatusName === 'cancelado').length

        rowsData.push({
          name: entity.name,
          agendado,
          finalizado,
          aguardandoPagamento,
          cancelado
        })
      }

      rows.value = rowsData
    }

    onMounted(() => {
      populateTable()
    })

    return {
      rows,
      columns,
      onRowClick: (row) => alert(`${row.name} clicked`)
    }
  }
}
</script>

<style scoped>
.primeira {
  display: block;
  justify-content: center;
  align-items: center;
  background: #ebebeb;
  border-radius: 25px;
  width: 40%;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  padding: 20px;
}

h2 {
  color: #17a2b8;
  padding-top: 10px;
  font-size: 30px;
  text-align: center;
}

.form {
  -webkit-transition: -webkit-transform 1.2s ease-in-out;
  transition: -webkit-transform 1.2s ease-in-out;
  transition: transform 1.2s ease-in-out;
  transition: transform 1.2s ease-in-out, -webkit-transform 1.2s ease-in-out;
}

label {
  display: block;
  width: 100%;
  margin: 15px auto 0;
}

label span {
  font-size: 14px;
  font-weight: 600;
  color: #17a2b8;
  text-transform: uppercase;
}

input {
  display: flex;
  width: 100%;
  margin-top: 5px;
  font-size: 16px;
  padding-bottom: 5px;
  border-bottom: 1px solid rgba(185, 77, 77, 0.4);
  text-align: center;
  font-family: 'Nunito', sans-serif;
}

button {
  display: block;
  margin: 20px auto;
  width: 100%;
  height: 36px;
  border-radius: 30px;
  background-color: #26a69a;
  color: white;
  font-size: 15px;
  cursor: pointer;
}

button:hover {
  background-color: rgb(43, 233, 91);
}

.salvar-senha-label {
  color: rgb(64, 166, 184);
}

@media only screen and (max-width: 767px) {
  .primeira {
    width: 90%;
  }
}
</style>
