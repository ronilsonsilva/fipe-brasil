<template>
  <v-container>
    <brand-grid
      :brands="brands"
      :total-items="totalItems"
      :items-per-page="itemsPerPage"
      :current-page="currentPage"
      @page-changed="handlePageChange"
      @items-per-page-changed="handleItemsPerPageChange"
    />
  </v-container>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from "vue";
import axios from "axios";
import { Brand } from "@/models/Brand";
import BrandGrid from "../components/BrandGrid.vue";

export default defineComponent({
  name: "HomeView",

  components: {
    BrandGrid,
  },

  setup() {
    const brands = ref<Brand[]>([]);
    const totalItems = ref(0);
    const itemsPerPage = ref(10);
    const currentPage = ref(1);

    const fetchBrands = async () => {
      try {
        const response = await axios.get(
          `https://localhost:44302/api/Brand?page=${currentPage.value}&pageSize=${itemsPerPage.value}`
        );
        brands.value = response.data.brands;
        totalItems.value = response.data.counts;
      } catch (error) {
        console.error("Error fetching brands:", error);
      }
    };

    const handlePageChange = (newPage: number) => {
      currentPage.value = newPage;
      fetchBrands();
    };

    const handleItemsPerPageChange = (newItemsPerPage: number) => {
      itemsPerPage.value = newItemsPerPage;
      currentPage.value = 1;
      fetchBrands();
    };

    onMounted(() => {
      fetchBrands();
    });

    return {
      brands,
      totalItems,
      itemsPerPage,
      currentPage,
      handlePageChange,
      handleItemsPerPageChange,
    };
  },
});
</script>
