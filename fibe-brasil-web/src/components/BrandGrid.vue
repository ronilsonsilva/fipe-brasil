<template>
  <v-data-table
    :headers="headers"
    :items="brands"
    :items-per-page="10"
    :server-items-length="totalItems"
    :loading="false"
    class="elevation-1"
  >
    <template #bottom>
      <div class="text-center pt-2 pb-2">
        <v-pagination
          v-model="page"
          :length="Math.ceil(totalItems / 10)"
          :total-visible="7"
          @update:model-value="onPageChange"
        ></v-pagination>
      </div>
    </template>

    <template #top>
      <v-toolbar flat>
        <v-toolbar-title>Brand List</v-toolbar-title>
        <v-divider class="mx-4" inset vertical></v-divider>
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
import { defineComponent, ref, PropType } from "vue";
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
    currentPage: {
      type: Number,
      default: 1,
    },
  },
  emits: ["page-changed"],

  setup(props, { emit }) {
    const search = ref("");
    const page = ref(props.currentPage);

    const headers = [
      { title: "Code", key: "code" },
      { title: "Name", key: "name" },
    ];

    const onPageChange = (newPage: number) => {
      console.log("Page changed to:", newPage);
      emit("page-changed", newPage);
    };

    return {
      search,
      headers,
      page,
      onPageChange,
    };
  },
});
</script>
