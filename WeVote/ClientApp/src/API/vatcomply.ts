import { useQuery } from "@tanstack/react-query";

interface GeolocateAPI {
  ip: string;
  name: string;
  currency: string;
}

interface Geolocate {
  ip: string;
  countryName: string;
  currencyCode: string;
}

const VATCOMPLY_URL = "https://api.vatcomply.com/";

const GEOLOCATE_ENDPOINT = "geolocate";
const getGeolocate = async (): Promise<Geolocate> => {
  return await fetch(`${VATCOMPLY_URL}${GEOLOCATE_ENDPOINT}`)
    .then(async (response) => (await response.json()) as GeolocateAPI)
    .then((data) => {
      return {
        ip: data.ip,
        countryName: data.name,
        currencyCode: data.currency,
      };
    });
};

interface Currency {
  name: string;
  symbol: string;
}

interface CurrencyAPI {
  [currencyCode: string]: Currency;
}

const CURRENCIES_ENDPOINT = "currencies";
const getCurrency = async (currencyCode: string) => {
  return await fetch(`${VATCOMPLY_URL}${CURRENCIES_ENDPOINT}`)
    .then(async (response) => (await response.json()) as CurrencyAPI)
    .then((data) => {
      if (!data[currencyCode]) {
        return {
          currencyName: "No soportado",
          currencySymbol: "NAN",
        };
      }
      return {
        currencyName: data[currencyCode].name,
        currencySymbol: data[currencyCode].symbol,
      };
    });
};

const getUserData = async () => {
  const geolocate = await getGeolocate();
  const currency = await getCurrency(geolocate.currencyCode);
  return {
    ...geolocate,
    ...currency,
  };
};

export const useGetUserData = () => {
  return useQuery({
    queryKey: ["USER_DATA"],
    queryFn: () => getUserData(),
  });
};
