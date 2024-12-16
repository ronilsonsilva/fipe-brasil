import axios from "axios";

const BASE_URL = "https://localhost:44302/api/Brand";

export interface Brand {
  id: string;
  code: string;
  name: string;
}

export async function fetchBrands(
  page: number,
  pageSize: number
): Promise<Brand[]> {
  try {
    const response = await axios.get(
      `${BASE_URL}?page=${page}&pageSize=${pageSize}`
    );
    return response.data;
  } catch (error) {
    console.error("Error fetching brands:", error);
    throw error;
  }
}
