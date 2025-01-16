<template>
  <v-container>
    <brand-grid
      :brands="brands"
      :total-items="totalItems"
      :current-page="currentPage"
      @page-changed="handlePageChange"
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
    const currentPage = ref(1);
    const itemsPerPage = 10; // Fixed value

    const fetchBrands = async () => {
      try {
        // API usa paginação baseada em 1, então usamos o currentPage diretamente
        console.log("Fetching data:", {
          page: currentPage.value,
          pageSize: itemsPerPage,
        });

        const response = await axios.get(
          `https://localhost:44302/api/Brand?page=${currentPage.value}&pageSize=${itemsPerPage}`
        );

        brands.value = response.data.brands;
        totalItems.value = response.data.counts;

        console.log("API Response:", {
          page: currentPage.value,
          items: brands.value.length,
          total: response.data.counts,
          firstItem: brands.value[0]?.name,
          lastItem: brands.value[brands.value.length - 1]?.name,
        });
      } catch (error) {
        console.error("Error fetching brands:", error);
      }
    };

    const handlePageChange = async (page: number) => {
      console.log("Page changed to:", page);
      currentPage.value = page;
      await fetchBrands();
    };

    onMounted(() => {
      fetchBrands();
    });

    return {
      brands,
      totalItems,
      currentPage,
      handlePageChange,
    };
  },
});
</script>
