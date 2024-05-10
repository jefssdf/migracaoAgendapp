<template>
  <div class="q-pa-md">
    <q-table
      style
      flat bordered
      ref="tableRef"
      title="Agendamentos"
      :rows="rows"
      :columns="columns"
      :table-colspan="9"
      row-key="index"
    >
      <template v-slot:body="props">
        <q-tr>
          <q-td key="name" :props="props">
            {{ props.row.name }}
          </q-td>
          <q-td key="contatos" :props="props">
            {{ props.row.contatos }}
          </q-td>
          <q-td key="Data" :props="props">
            {{ props.row.Data }}
          </q-td>
          <q-td key="Hora" :props="props">
            {{ props.row.hora }}
          </q-td>
          <q-td key="Especialidade" :props="props">
            {{ props.row.especialidade }}
          </q-td>
          <q-td key="Serviço" :props="props">
            {{ props.row.servico }}
          </q-td>
          <q-td q-td class="text-right" >
            <q-btn  color=red label="Desmarcar" @click="handleButtonClick(props.row)" />
          </q-td>
        </q-tr>
      </template>
    </q-table>
  </div>
</template>

<script>
import { useRouter } from 'vue-router'

export default {
  setup () {
    const router = useRouter()

    const columns = [
      {
        name: 'name',
        required: true,
        label: ' Nome ',
        align: 'left',
        field: row => row.name,
        format: val => `${val}`,
        sortable: true
      },
      { name: 'contatos', align: 'center', label: 'Contato', field: 'contatos', sortable: true },
      { name: 'Data', label: 'Data', field: 'fat', sortable: true },
      { name: 'Hora', label: 'Hora', field: 'hora', sortable: true },
      { name: 'Especialidade', label: 'Especialidade', field: 'especialidade' },
      { name: 'Serviço', label: 'Serviço', field: 'servico' }
    ]

    const rows = [
      {
        name: 'Igor',
        contatos: '9999-1212',
        Data: '06/05/2024',
        hora: '20:32',
        especialidade: 'Nutricionista',
        servico: 'Serviço A'
      },
      {
        name: 'Joana',
        contatos: '8888-3434',
        Data: '07/05/2024',
        hora: '15:45',
        especialidade: 'Psicóloga',
        servico: 'Serviço B'
      },
      {
        name: 'Pedro',
        contatos: '7777-5656',
        Data: '08/05/2024',
        hora: '09:00',
        especialidade: 'Fisioterapeuta',
        servico: 'Serviço C'
      },
      {
        name: 'Mariana',
        contatos: '6666-7878',
        Data: '09/05/2024',
        hora: '14:30',
        especialidade: 'Dentista',
        servico: 'Serviço D'
      },
      {
        name: 'Lucas',
        contatos: '5555-9090',
        Data: '10/05/2024',
        hora: '11:15',
        especialidade: 'Nutricionista',
        servico: 'Serviço E'
      }
    ]
    const handleButtonClick = (row) => {
      router.push({ name: 'AgendarConsultas' })
    }

    return {
      columns,
      rows,
      handleButtonClick
    }
  }
}
</script>

<style>
.text-right {
  text-align: right;
}

button {
  display: block;
  width: 100%;
  height: 36px;
  border-radius: 30px;
  background-color: #26a69a;
  color: white;
  font-size: 15px;
  cursor: pointer;
}
</style>
