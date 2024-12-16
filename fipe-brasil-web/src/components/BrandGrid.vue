<template>
  <v-data-table
    :items="brands"
    :headers="headers"
    item-value="id"
    class="elevation-1"
    :server-items-length="totalItems"
    v-model:page="localPage"
    v-model:items-per-page="currentItemsPerPage"
  >
    <template #top>
      <v-toolbar flat>
        <v-toolbar-title>Brand List</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-text-field
          v-model="search"
          label="Search"
          single-line
          hide-details
        ></v-text-field>
      </v-toolbar>
    </template>
  </v-data-table>
</template>

<script lang="ts">
import { defineComponent, ref, watch, PropType } from "vue";
import { Brand } from "@/models/Brand";

export default defineComponent({
  name: "BrandGrid",
  props: {
    brands: {
      type: Array as PropType<Brand[]>,
      required: true,
    },
    totalItems: {
      type: Number,
      required: true,
    },
    itemsPerPage: {
      type: Number,
      default: 10,
    },
    currentPage: {
      type: Number,
      default: 1,
    },
  },
  emits: ["page-changed", "items-per-page-changed"],

  setup(props, { emit }) {
    const search = ref("");
    const headers = ref([
      { text: "Code", value: "code" },
      { text: "Name", value: "name" },
    ]);

    const localPage = ref(props.currentPage);
    const currentItemsPerPage = ref(props.itemsPerPage);

    watch(localPage, (newPage) => {
      emit("page-changed", newPage);
    });

    watch(currentItemsPerPage, (newItemsPerPage) => {
      emit("items-per-page-changed", newItemsPerPage);
    });

    return { search, headers, localPage, currentItemsPerPage };
  },
});
</script>
