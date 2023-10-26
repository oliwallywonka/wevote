import { useQuery } from "@tanstack/react-query";

export interface Visit {
  ip: string;
  countryName: string;
  currencyCode: string;
  currencyName: string;
  currencySymbol: string;
}

const BACKEND_URL = "http://localhost:5111/";

const SAVE_VISIT_ENDPOINT = "api/visit";
export const saveVisit = async (visit: Visit) => {
  return await fetch(`${BACKEND_URL}${SAVE_VISIT_ENDPOINT}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(visit),
  })
    .then(async (response) => await response.json())
    .then((data) => {
      return data.message;
    });
};

export const useSaveVisit = (visit: Visit) => {
  return useQuery({
    queryKey: ["POST_DATA"],
    queryFn: () => saveVisit(visit),
  });
};
