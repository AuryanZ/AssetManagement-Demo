"use client"
import React, { useRef } from "react";
import { useEffect, useState } from "react";
import AssetsTable from "@/components/Assets/assets_table";
import { getAssetsByCondition } from "@/api/assets/getAssets";


const AssetSearch = () => {
    const [state, setState] = useState({ assets: [], loading: true });
    const [page, setPage] = useState(1);
    const [itemsPerPage, setItemsPerPage] = useState(5);
    const assetsDataCount = useRef(0);

    useEffect(() => {
        const fetchData = async () => {
            const assetsFetch = await getAssetsByCondition(page, itemsPerPage);
            console.log("assetsFetch ", assetsFetch.data);
            // Not complete, need to handle errors
            if (assetsFetch.status === 401) {
                window.location.href = '/auth/login';

                // console.log("Error fetching status ", assetsFetch.status);
                // console.log("Error fetching test ", assetsFetch.statusText);
            } else {
                setState({ assets: assetsFetch.data.assets, loading: false });
                assetsDataCount.current = assetsFetch.data.count;
            }
        };
        fetchData()
    }, [page, itemsPerPage]);

    const handlePageChange = (newPage: number) => {
        if (newPage <= 1) {
            setPage(1);
            return;
        }
        if(newPage >= Math.ceil(assetsDataCount.current / itemsPerPage)) {
            setPage(Math.ceil(assetsDataCount.current / itemsPerPage));
            return;
        }
        setPage(newPage);
    };

    const handleItemsPerPageChange = (newItemsPerPage: number) => {
        if (newItemsPerPage <= 1) {
            setItemsPerPage(5);
            return;
        }
        console.log("newItemsPerPage ", newItemsPerPage);
        setItemsPerPage(newItemsPerPage);
    };

    if (state.loading) {
        return <div>Loading...</div>;
    }

    return (
        <div className="col-span-5 pt-4">
            <div className="ItemPerPage px-4">
                <label htmlFor="itemsPerPage">Items per page: </label>
                <select
                    id="itemsPerPage"
                    value={itemsPerPage}
                    onChange={(e) => handleItemsPerPageChange(Number(e.target.value))}
                    className="border-2"
                >
                    <option value="5">5</option>
                    <option value="10">10</option>
                    <option value="15">15</option>
                    <option value="20">20</option>
                </select>
                <label> /Total: {assetsDataCount.current}</label>
            </div>
            <div className="p-4 flex justify-center">
                <AssetsTable assetsData={state.assets} />


            </div>
            <div className="p-4 flex justify-center">
                <button onClick={() => handlePageChange(page - 1)} className="px-2">Previous</button>
                <div> </div>
                <button onClick={() => handlePageChange(page + 1)}  className="px-2">Next</button>
            </div>
        </div>
    );
}

export default AssetSearch;