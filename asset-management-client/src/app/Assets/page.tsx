"use client"
import { getAssets } from "@/api/assetsAPI";
import React from "react";
import { useEffect, useState } from "react";
import AssetsTable from "@/components/Assets/assets_table";


const AssetSearch = () => {
    const [state, setState] = useState({ assets: [], loading: true });
    const [page, setPage] = useState(1);
    const [itemsPerPage, setItemsPerPage] = useState(3);

    useEffect(() => {
        const fetchData = async () => {
            const assetsFetch = await getAssets();
            setState({ assets: assetsFetch.data, loading: false });
        };
        fetchData()
    }, [page, itemsPerPage]);

    const handlePageChange = (newPage: number) => {
        console.log("newPage ", newPage);
        if (newPage <= 1) {
            setPage(1);
            return;
        }
        setPage(newPage);
    };

    const handleItemsPerPageChange = (newItemsPerPage: number) => {
        if (newItemsPerPage <= 1) {
            setItemsPerPage(1);
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
            <div className="px-4">
                <div className="px-4">
                    <label htmlFor="itemsPerPage">Items per page: </label>
                    <select
                        id="itemsPerPage"
                        value={itemsPerPage}
                        onChange={(e) => handleItemsPerPageChange(Number(e.target.value))}
                        className="border-4"
                    >
                        <option value="5">5</option>
                        <option value="10">10</option>
                        <option value="15">15</option>
                        <option value="20">20</option>
                    </select>
                </div>
                <AssetsTable assetsData={state.assets} />
                <div className="px-4 flex">
                    <button onClick={() => handlePageChange(page - 1)}>Previous</button>
                    <div>1,2,3....8,9,10</div>
                    <button onClick={() => handlePageChange(page + 1)}>Next</button>
                </div>
                <div className="px-4">
                </div>
            </div>
        </div>
    );
}

export default AssetSearch;